using ContactBook.Models;
using ContactBook.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactBook.ViewModels
{
    public class ContactDetailViewModel
    {
        private readonly IContactStore _contactStore;
        private readonly IPageService _pageService;

        public Contact Contact { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ContactDetailViewModel(ContactViewModel viewModel, IContactStore contactStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _contactStore = contactStore;

            SaveCommand = new Command(async () => await Save());

            Contact = new Contact
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                IsBlocked = viewModel.IsBlocked
            };
        }

        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Contact.FirstName) && String.IsNullOrWhiteSpace(Contact.LastName))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (Contact.Id == 0)
            {
                await _contactStore.Add(Contact);
                MessagingCenter.Send(this, Events.ContactAdded, Contact);
            }
            else
            {
                await _contactStore.Update(Contact);
                MessagingCenter.Send(this, Events.ContactUpdated, Contact);
            }

            await _pageService.PopAsync();
        }
    }
}
