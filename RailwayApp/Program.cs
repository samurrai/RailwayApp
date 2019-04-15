using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var config = new TicketConfig())
            {
                #region Инициализация и добавление
                //City cityAstana = new City() {
                //    Name = "Astana"
                //};
                //City cityAlmaty = new City()
                //{
                //    Name = "Almaty"
                //};
                //City cityKostanay = new City()
                //{
                //    Name = "Kostanay"
                //};
                //City cityKaraganda = new City()
                //{
                //    Name = "Karaganda"
                //};
                //City cityZhezkazgan = new City()
                //{
                //    Name = "Zhezkazgan"
                //};
                //City cityShymkent = new City()
                //{
                //    Name = "Shymkent"
                //};

                //List<City> cities = new List<City>();
                //cities.Add(cityAstana);
                //cities.Add(cityAlmaty);
                //cities.Add(cityKaraganda);
                //cities.Add(cityKostanay);
                //cities.Add(cityShymkent);
                //cities.Add(cityZhezkazgan);

                //List<Ticket> tickets = new List<Ticket>();

                //Random random = new Random();

                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[0],
                //    CityTo = cities[5],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[1],
                //    CityTo = cities[2],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[3],
                //    CityTo = cities[1],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[4],
                //    CityTo = cities[0],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[5],
                //    CityTo = cities[3],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[1],
                //    CityTo = cities[4],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[4],
                //    CityTo = cities[5],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[3],
                //    CityTo = cities[5],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[4],
                //    CityTo = cities[2],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[1],
                //    CityTo = cities[0],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[5],
                //    CityTo = cities[2],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[3],
                //    CityTo = cities[0],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //tickets.Add(new Ticket()
                //{
                //    CityFrom = cities[2],
                //    CityTo = cities[0],
                //    Date = new DateTime(2019, random.Next(1, 12), random.Next(1, 31))
                //});
                //config.Cities.AddRange(cities);
                //config.Tickets.AddRange(tickets);
                //config.SaveChanges();
                #endregion

                var tickets = config.Tickets.Include("CityFrom").Include("CityTo");
                Console.WriteLine("Доступные маршруты:");
                foreach (var ticket in tickets)
                {
                    Console.WriteLine(ticket.CityFrom.Name);
                    Console.WriteLine(ticket.CityTo.Name);
                    Console.WriteLine(ticket.Date);
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------------------");

                string from;
                while (true)
                {
                    Console.Write("Откуда: ");
                    from = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(from))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите город отправления");
                    }
                }

                string to;
                while (true)
                {
                    Console.Write("Куда: ");
                    to = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(to))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите город прибытия");
                    }
                }
                bool isFound = false;
                foreach (var ticket in tickets)
                {
                    if (ticket.CityFrom.Name.ToLower() == from.ToLower() && ticket.CityTo.Name.ToLower() == to.ToLower())
                    {
                        isFound = true;
                        Console.WriteLine($"Город отправления - {from}, город прибытия - {to}, дата - {ticket.Date.Day}/{ticket.Date.Month}/{ticket.Date.Year}");
                    }
                }
                if (!isFound)
                {
                    Console.WriteLine("Билеты не найдены");
                }
                Console.WriteLine("Нажмите enter для продолжения");
                Console.ReadLine();
            }
        }
    }
}
