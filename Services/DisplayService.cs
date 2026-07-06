using CityLibrarySystem.Models;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Services
{
    public class DisplayService
    {
        public void ShowBranchInfo(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("LIBRARY BRANCH INFO");
            Console.WriteLine(branch.ToDisplay());
        }


        public void ShowAllUsers(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Registered Users");
            IReadOnlyList<LibraryUser> users = branch.Users;    
            for (int i = 0; i < users.Count; i++)
            {
                string header = users[i] is Librarian ? "LIBRARIAN PROFILE" : "MEMBER PROFILE";
                ThemeHelper.PrintSectionTitle(header);
                Console.WriteLine(users[i].ToDisplay());
            }

        }


        public void ShowAvailableBookCopies(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("Available Book Copies: ");
            IReadOnlyList<BookCopy> books = branch.GetAvailableCopies();
            if (books.Count == 0)
            {
                ThemeHelper.PrintWarning("No available book copies found !!");
                return;
            }
            else
            {
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine(books[i].ToDisplay());
                }
            }

        }


        public void ShowAllBookCopies(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Book Copies");
            if (branch.BookCopies.Count == 0)
            {
                ThemeHelper.PrintWarning("No book copies found !!");
                return;
            }
            else
            {
                for (int i = 0; i < branch.BookCopies.Count; i++)
                {
                    Console.WriteLine(branch.BookCopies[i].ToDisplay());
                }
            }

        }


        public void ShowMemberHistory(Member member)
        {
            ThemeHelper.PrintSectionTitle($"Borrowing History For {member.MembershipId}");
            Console.WriteLine(member.GetHistoryDisplayString());
        }


        public void ShowBorrowSuccess(BookCopy copy , Member member)
        {
            ThemeHelper.PrintSuccess($"Copy {copy.CopyId} : {copy.Book.Title} Borrowed by {member.Name}");
            ThemeHelper.PrintSuccess($"Due Date : {copy.ActiveTransaction!.DueDate:dd/MM/yyyy}");
        }


        public void ShowReturnSuccess(BookCopy copy, decimal fine)
        {
            ThemeHelper.PrintSuccess($"Copy [{copy.CopyId}]: {copy.Book.Title} returned.");
            if (fine > 0)
                ThemeHelper.PrintWarning($"Late return fine: {fine:F2} EGP");
            else
                ThemeHelper.PrintSuccess("Returned on time. No fine.");
        }


        public void ShowRegistrationSuccess(Member member)
        {
            ThemeHelper.PrintSuccess($"Member: {member.Name} - [{member.MembershipId}] registered.");
        }


        public void ShowAddCopySuccess(BookCopy copy)
        {
            ThemeHelper.PrintSuccess($"Copy [{copy.CopyId}] - {copy.Book.Title}: added to branch.");
        }
    }
}
