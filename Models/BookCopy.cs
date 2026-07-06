using CityLibrarySystem.Contracts;
using CityLibrarySystem.Models.Enums;

namespace CityLibrarySystem.Models
{
    public class BookCopy : IDisplayable, IBorrowable
    {
        public string CopyId { get; private set; }
        public string Condition { get; private set; }
        public CopyStatus Status { get; private set; }
        public Book Book { get; private set; }
        public BorrowTransaction? ActiveTransaction { get; private set; }



        public BookCopy(string copyId , Book book , string condition = "Good")
        {
            CopyId = copyId;
            Book = book;
            Condition = condition;
            Status = CopyStatus.Available;     
        }








        public string ToDisplay()
        {
            string avail = IsAvailable() ? "Available" : $"{Status}";
            return $"Copy [{CopyId}] — {Book.Title} | Condition: {Condition} | {avail}";
        }

        public decimal Return()
        {
            if (ActiveTransaction == null) 
                throw new InvalidOperationException($"No Active Transaction For this Copy {CopyId}");

            if (Status != CopyStatus.Borrowed)
                throw new InvalidOperationException($"Copy {CopyId} Is Not Borrowed !!");

            ActiveTransaction.MarkReturned(DateOnly.FromDateTime(DateTime.Now));
            decimal fine = ActiveTransaction.CalculateFine();
            Status = CopyStatus.Available;
            ActiveTransaction = null;
            return fine;

        }

        public bool IsAvailable() => Status == CopyStatus.Available;

        public void Borrow(Member member, int loanDays = 14)
        {
            // Check Book Copy Status
            if (!IsAvailable())
                throw new InvalidOperationException($"Copy {CopyId} is not Available !!!");
            // Change Book Copy Status
             Status = CopyStatus.Borrowed;
            // Create Transaction 
            ActiveTransaction = new BorrowTransaction(member, this, loanDays);
            // Add Transaction to Member
            member.AddTransaction(ActiveTransaction);
        }
    }
}