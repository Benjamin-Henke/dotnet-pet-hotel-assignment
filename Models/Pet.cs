using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType 
    {
        Shepherd, 
        Poodle, 
        Beagle, 
        Bulldog, 
        Terrier, 
        Boxer, 
        Labrador, 
        Retriever
    }
        
    public enum PetColorType 
    {
        White,
        Black, 
        Golden, 
        Tricolor, 
        Spotted
    }

    public class Pet 
    {
        public int id { get; set; }

        [Required]
        public string name {get; set;}

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? checkedInAt { get; set; }

        [ForeignKey("PetOwner")]
        public int petOwnerId { get; set; }

        public PetOwner petOwner { get; set; }
    }
}
