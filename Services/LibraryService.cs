using CityLibrarySystem.Extensions;
using CityLibrarySystem.Models;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Services
{
    public class LibraryService
    {
        private readonly LibraryBranch _branch;
        private readonly DisplayService _displayService;

        public LibraryService(LibraryBranch branch, DisplayService displayService)
        {
            _branch = branch;
            _displayService = displayService;
        }

        public void HandleBorrow()
        {
            string memberId = ThemeHelper.Prompt("Member Id ").Normalize();
            Member member = _branch.FindMember(memberId);
            _displayService.ShowAvailableBookCopies(_branch);

            string copyId = ThemeHelper.Prompt("Copy Id To Borrow : ").Normalize();
            BookCopy copy = _branch.FindCopy(copyId);

            copy.Borrow(member);
            _displayService.ShowBorrowSuccess(copy , member);
        }

        public void HandleReturn()
        {
            string copyId = ThemeHelper.Prompt("Copy Id To Return : ").Normalize();
            BookCopy bookCopy = _branch.FindCopy(copyId); 

            decimal fine =  bookCopy.Return();
            _displayService.ShowReturnSuccess(bookCopy , fine);
        }

        public void HandleHistory()
        {
            string memberId = ThemeHelper.Prompt("Member Id ").Normalize();
            Member member = _branch.FindMember(memberId);
            _displayService.ShowMemberHistory(member);
        }

        public void HandleRegisterMember()
        {
            string name = ThemeHelper.Prompt("Full Name ");

            string phone = ThemeHelper.Prompt("Phone Number ");
            if (phone.IsValidPhone())
                throw new InvalidOperationException("Phone Number is not Valid !!!");

            string email = ThemeHelper.Prompt("Email ");
            if (email.IsValidEmail())
                throw new InvalidOperationException("Email is not Valid !!!");

           Member member = _branch.RegisterMember(name, null , email , phone, DateOnly.FromDateTime(DateTime.Today));
            _displayService.ShowRegistrationSuccess(member);
        }
    }
}
