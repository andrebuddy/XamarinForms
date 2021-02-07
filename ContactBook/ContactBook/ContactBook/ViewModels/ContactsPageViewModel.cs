using ContactBook.Services;
using ContactBook.Views;
using System.Collections.ObjectModel;
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
            var viewModel = new ContactDetailViewModel(
                new ContactViewModel(),
                _contactStore,
                _pageService);

            viewModel.ContactAdded += (source, contact) =>
            {
                Contacts.Add(new ContactViewModel(contact));
            };

            await _pageService.PushAsync(new ContactDetailPage(viewModel));
        }

        private async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            var viewModel = new ContactDetailViewModel(contact, _contactStore, _pageService);
            viewModel.ContactUpdated += (source, updatedContact) =>
            {
                contact.Id = updatedContact.Id;
                contact.FirstName = updatedContact.FirstName;
                contact.LastName = updatedContact.LastName;
                contact.Phone = updatedContact.Phone;
                contact.Email = updatedContact.Email;
                contact.IsBlocked = updatedContact.IsBlocked;
            };

            await _pageService.PushAsync(new ContactDetailPage(viewModel));
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
