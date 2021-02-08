using ContactBook.Models;
using ContactBook.Services;
using ContactBook.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactBook.ViewModels
{
    public class ContactsPageViewModel : BaseViewModel
    {
        private readonly IContactStore _contactStore;
        private readonly IPageService _pageService;
        private ContactViewModel _selectedContact;
        private bool _isDataLoaded;

        public ObservableCollection<ContactViewModel> Contacts { get; private set; }
            = new ObservableCollection<ContactViewModel>();

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
        }

        // Commands
        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }
        public ICommand SelectContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactsPageViewModel(IPageService pageService, IContactStore store)
        {
            _pageService = pageService;
            _contactStore = store;

            LoadDataCommand = new Command(async () => await LoadData());
            AddContactCommand = new Command<ContactViewModel>(async vm => await AddContact());
            SelectContactCommand = new Command<ContactViewModel>(async vm => await SelectContact(vm));
            DeleteContactCommand = new Command<ContactViewModel>(async vm => await DeleteContact(vm));

            // Subscribe to events
            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>
                (this, Events.ContactAdded, OnContactAdded);
            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>
                (this, Events.ContactUpdated, OnContactUpdated);
        }

        private void OnContactAdded(ContactDetailViewModel source, Contact contact)
        {
            Contacts.Add(new ContactViewModel(contact));
        }

        private void OnContactUpdated(ContactDetailViewModel source, Contact contact)
        {
            // Here we need to find the corresponding Contact object in our
            // ObservableCollection first.
            var contactInList = Contacts.Single(c => c.Id == contact.Id);

            contactInList.Id = contact.Id;
            contactInList.FirstName = contact.FirstName;
            contactInList.LastName = contact.LastName;
            contactInList.Phone = contact.Phone;
            contactInList.Email = contact.Email;
            contactInList.IsBlocked = contact.IsBlocked;
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;

            var contacts = await _contactStore.GetAllAsync();
            foreach (var c in contacts)
                Contacts.Add(new ContactViewModel(c));
        }

        private async Task AddContact()
        {
            await _pageService.PushAsync(new ContactDetailPage(new ContactViewModel()));
        }

        private async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            await _pageService.PushAsync(new ContactDetailPage(contact));
        }

        private async Task DeleteContact(ContactViewModel contact)
        {
            if (await _pageService.DisplayAlert(
                "Delete contact?",
                $"Are you sure you want to delete {contact.FullName}",
                "Yes",
                "No"))
            {
                Contacts.Remove(contact);
            }

            var contactInDb = await _contactStore.Get(contact.Id);
            await _contactStore.Delete(contactInDb.Id);
        }
    }
}
