using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace LibraryStore.Models
{
    public sealed record Book
    {
        [FromForm, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }
        [FromForm]
        public string PublishCode { get; init; }
        [FromForm]
        public string AuthorCode { get; init; }
        [FromForm]
        public string Name { get; init; }
        [FromForm]
        public int PublishYear { get; init; }
        [FromForm]
        public string ShortDescription { get; init; }
        [FromForm]
        public string StorageCode { get; init; }
        [FromForm]
        public string ImageUrl { get; init; }
    }
}