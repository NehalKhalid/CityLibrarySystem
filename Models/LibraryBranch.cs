using CityLibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    public class LibraryBranch : IDisplayable
    {
        public string BranchId { get; private set; }
        public string BranchName { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string OpeningHours { get; private set; }
        public Librarian Manager { get; set; }


        private readonly List<BookCopy> copies = new();
        private readonly List<Member> members = new();

        public IReadOnlyList<Member> Members => members;
        public IReadOnlyList<BookCopy> BookCopies => copies;

        // Returns all users (manager + members) as a single read-only list.
        public IReadOnlyList<LibraryUser> Users
        {
            get
            {
                List<LibraryUser> users = new();
                users.Add(Manager);
                users.AddRange(Members);
                return users;
            }
        }

        public LibraryBranch(string branchId, string branchName, string address, string phone, string openingHours, Librarian manager)
        {
            BranchId = branchId;
            BranchName = branchName;
            Address = address;
            Phone = phone;
            OpeningHours = openingHours;
            Manager = manager;
        }

        public Member RegisterMember(string name , string phone)
        {
            Member member = new Member(name, phone);
            members.Add(member);
            return member;
        }

        public Member RegisterMember(string name, DateOnly? birthDate , string email ,string phone , DateOnly membershipDate)
        {
            Member member = new Member(name, birthDate , email , phone , membershipDate);
            members.Add(member);
            return member;
        }



        public Member FindMember(string id)
        {
            string normalized = id.Normalize();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].MembershipId == normalized)
                    return members[i];
            }
            throw new InvalidOperationException("Member Not Found !!!");
        }

        public BookCopy FindCopy(string id)
        {
            string normalized = id.Normalize();
            for (int i = 0; i < copies.Count; i++)
            {
                if (copies[i].CopyId == normalized)
                    return copies[i];
            }
            throw new InvalidOperationException("Book Copy Not Found !!!");
        }

        public void AddBookCopy(BookCopy copy) => copies.Add(copy);

        public List<BookCopy> GetAvailableCopies()
        {
            List<BookCopy> availCopies = new();
            foreach(BookCopy copy in copies)
            {
                if(copy.IsAvailable())
                    availCopies.Add(copy);
            }
            return availCopies;
        }



        public string ToDisplay() => $@"ID : {BranchId}
Name : {BranchName}
Address : {Address}
Phone : {Phone}
Opening Hours : {OpeningHours}
Manager : {Manager.Name}
Total Members : {members.Count}
Total Book Copies : {copies.Count}";
    }
}
