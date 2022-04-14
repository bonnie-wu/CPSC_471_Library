using System.Net.Http.Json;

namespace CPSC_471_Library.Client.Services.StaffService
{
    public class StaffService : IStaffService
    {
        private HttpClient http;

        public StaffService(HttpClient http)
        {
            this.http = http;
        }

        public List<Staff> Staffs { get; set; } = new List<Staff>();

        public List<LibraryCard> Cards { get; set; } = new List<LibraryCard>();
        public List<Loan> Loans { get; set; } = new List<Loan>();
        public List<Hold> Holds { get; set; } = new List<Hold>();
        public HttpClient Http { get; }

        public async Task<Staff> GetStaffMember(string num)
        {
            var result = await http.GetFromJsonAsync<Staff>($"api/Staff/{num}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Staff member not found.");
        }

        public async Task GetStaff()
        {
            var result = await http.GetFromJsonAsync<List<Staff>>("api/Staff");
            if (result != null)
                Staffs = result;
        }

        public async Task<LibraryCard> AddLibraryCard(LibraryCard card)
        {
            card.Card_number = RandomString(5);
            await http.PostAsJsonAsync<LibraryCard>($"api/LibraryCard", card);
            return card;
        }

        public async Task<Staff> AddStaff(Staff staff)
        {
            staff.Staff_num = RandomString(5);
            await http.PostAsJsonAsync<Staff>($"api/Staff", staff);
            return staff;
        }

        public async Task<Book> AddBook(Book book)
        {
            try
            {
                Book book_ = await GetBook(book.Title);
                return book_;
            }
            catch (Exception ex)
            {
                await http.PostAsJsonAsync<Book>($"api/Book", book);
                return null;
            }
            
            
        }

        public async Task<string> AddLoan(Loan loan)
        {
            try
            {
                Book book = await GetBook(loan.Title);
                if (book.Copies <= 0)
                    return "hold";
                await http.PostAsJsonAsync<Loan>($"api/Loan", loan);
                book.Copies--;
                await http.PutAsJsonAsync<Book>($"api/Book", book);
                return "Ok";
            }
            catch (Exception ex)
            {
                return "No book";
            }
            /*try
            {
                LibraryCard card = await GetCard(loan.Card_number);
            }
            catch (Exception e)
            {
                return "No card";
            }*/
        }

        public async Task<string> RemoveLoan(string num, string title)
        {
            var res = await http.DeleteAsync($"api/Loan/{title}/{num}");
            return "ok";
        }

        public async Task<string> RemoveStaff(string num)
        {
            try
            {
                Staff staff = await GetStaff(num);
                await http.DeleteAsync($"api/Staff/{staff.Id}");
                return "ok";
            }
            catch (Exception ex)
            {
                return "no staff";
            }
        }

        public async Task<string> RemoveCard(string num)
        {
            try
            {
                LibraryCard card = await GetCard(num);
                await http.DeleteAsync($"api/LibraryCard/{card.Id}");
                return "ok";
            }
            catch(Exception ex)
            {
                return "(card not found)";
            }
        }

        public async Task<Loan> GetLoan(string num, string title)
        {
            var res = await http.GetFromJsonAsync<Loan>($"api/Loan/{title}/{num}");
            if (res != null)
                return res;
            throw new Exception("No such loan");
        }
        public async Task<Staff> GetStaff(string num)
        {
            var res = await http.GetFromJsonAsync<Staff>($"api/Staff/{num}");
            if (res != null)
                return res;
            throw new Exception("No such staff number");
        }

        public async Task HoldItem(Hold hold)
        {
            await http.PostAsJsonAsync<Hold>($"api/Hold", hold);
        }

        public async Task GetHolds()
        {
            var result = await http.GetFromJsonAsync<List<Hold>>($"api/Hold");
            if (result != null)
                Holds = result;
        }

        public async Task GetLoans()
        {
            var result = await http.GetFromJsonAsync<List<Loan>>("api/Loan");
            if (result != null)
                Loans = result;
        }

        public async Task<LibraryCard> GetCard(string num)
        {
            var result = await http.GetFromJsonAsync<LibraryCard>($"api/LibraryCard/{num}");
            if (result != null)
                return result;
            throw new Exception("Card not found.");
        }

        public async Task<Book> GetBook(string title)
        {
            var result = await http.GetFromJsonAsync<Book>($"api/Book/books/{title}");
            if (result != null)
                return result;
            throw new Exception("Book not found.");
        }

        public async Task GetLibraryCards()
        {
            var result = await http.GetFromJsonAsync<List<LibraryCard>>("api/LibraryCard");
            if (result != null)
                Cards = result;
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
