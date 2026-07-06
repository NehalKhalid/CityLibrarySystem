using CityLibrarySystem.Contracts;
using Microsoft.VisualBasic;

namespace CityLibrarySystem.Models
{
    public class BorrowTransaction : IDisplayable
    {
        public int TransactionId { get; private set; }
        public Member Member { get; private set; }
        public BookCopy BookCopy { get; private set; }
        public DateOnly BorrowDate { get; private set; }
        public DateOnly DueDate { get; private set; }
        public DateOnly? ReturnDate { get; private set; }

        #region Private Fields
        private static int counter = 1000;
        private const decimal finePerDay = 10m;
        private const string dateFormat = "dd/MM/yyyy";
        #endregion

        public BorrowTransaction(Member member , BookCopy bookCopy , int loanDays)
        {
            TransactionId = ++counter;
            Member = member;
            BookCopy = bookCopy;
            BorrowDate = DateOnly.FromDateTime(DateTime.Today);
            DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(loanDays));
            ReturnDate = null;
        }

        // Is Returned Fun 
        public bool IsReturned() => ReturnDate.HasValue;

        // Calculate The Fine Fun
        public decimal CalculateFine()
        {
            DateOnly effDate = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
            int overDueDays = effDate.DayNumber - DueDate.DayNumber;
            return overDueDays > 0 ? overDueDays * finePerDay : 0;
        }
        public decimal CalculateFine(DateOnly returnDate)
        {
            int overDueDays = returnDate.DayNumber - DueDate.DayNumber;
            return overDueDays > 0 ? overDueDays * finePerDay : 0;
        }
        public void MarkReturned(DateOnly returnDate) => ReturnDate = returnDate;
        public string ToDisplay()
        {
            string status = ReturnDate.HasValue ? "Returned" : "Active";
            decimal fine = CalculateFine();
            string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToString(dateFormat) : "Not Returned Yet !!";
            string fineLine = fine > 0 ? $"{fine:F2} EGP" : "None";

            return $@"── Transaction #{TransactionId} ──────────────
Book      : {BookCopy.Book.Title}
Copy ID   : {BookCopy.CopyId}
Borrowed  : {BorrowDate.ToString(dateFormat)}
Due       : {DueDate.ToString(dateFormat)}
Returned  : {returnInfo}
Status    : {status}
Fine      : {fineLine}";
        }
    }
}