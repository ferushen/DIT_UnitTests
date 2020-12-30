using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("Books")]
    public class BookEntity
    {
        public int id { get; set; }
        
        public string name { get; set; }
        
        public string author { get; set; }
        
        public int year { get; set; }

        public BookEntity()
        {

        }

        public BookEntity(int NewId, string NewName, string NewAuthor, int NewYear)
        {
            id = NewId;
            name = NewName;
            author = NewAuthor;
            year = NewYear;
            Console.WriteLine($"New book: {NewName}, {NewYear}, author: {NewAuthor}");
        }
    }
}