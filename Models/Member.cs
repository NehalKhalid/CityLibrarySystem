using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    public class Member : LibraryUser
    {

        public string MembershipId { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }
        public string? Email { get; set; }
        public DateOnly MembershipDate { get; set; }

        private static int counter = 1;

        private readonly List<BorrowTransaction> transactions = new();

        public Member(string name  , DateOnly? dateOfBirth, string? email, string phone , DateOnly membershipDate) : base(name , phone)
        {
            MembershipId = $"MEM-{counter++:D3}";
            DateOfBirth = dateOfBirth;
            Email = email;
            MembershipDate = membershipDate;
        }

        // Add Transaction
        public void AddTransaction(BorrowTransaction transaction) => transactions.Add(transaction);


        public Member(string name, string phone): this(name , null , null , phone , DateOnly.FromDateTime(DateTime.Today)) { }
       
        public IReadOnlyList<BorrowTransaction> Transactions => transactions;

        public string GetHistoryDisplayString()
        {
            if (Transactions.Count == 0)
                return "No Transactions Found !!";

            StringBuilder result = new();
            for (int i = 0; i < Transactions.Count; i++)
            {
                result.AppendLine(Transactions[i].ToDisplay());
            }
            return result.ToString();
        }
        public override string ToDisplay()
        => $@"ID      : {MembershipId}
Name    : {Name}
Phone   : {Phone}
Email   : {Email ?? "N/A"}
Joined  : {MembershipDate:dd/MM/yyyy}
Borrows : {Transactions.Count}";
    }
}
