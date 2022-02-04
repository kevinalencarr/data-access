using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        // Insert below the connection string: server; database; user; password; server certification (should be True).
        // private const string CONNECTION_STRING = @"Server=;Database=;User ID=;Password=;TrustServerCertificate=True";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            // ReadUsers(connection);
            // ReadRoles(connection);
            // ReadTags(connection);
            // GetUser(connection);
            // CreateUser(connection);
            // UpdateUser(connection);

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.GetAll();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        public static void GetUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var getUser = repository.Get(1);

            Console.WriteLine(getUser.Name);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.GetAll();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.GetAll();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = new User()
            {
                Name = "Kevin Alencar",
                Email = "kevin@gmail.com",
                PasswordHash = "HASH",
                Bio = "Estudante",
                Image = "https://...",
                Slug = "kevin-alencar"
            };
            repository.Create(user);

            Console.WriteLine("O usuário foi criado com sucesso");
        }
    }
}