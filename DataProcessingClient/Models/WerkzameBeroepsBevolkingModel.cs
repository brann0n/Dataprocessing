using System;

namespace DataProcessingClient.Models
{
    public class WerkzameBeroepsBevolkingModel
    {
        public int Id { get; set; }
        public string Kenmerken { get; set; }
        public string Perioden { get; set; }
        public Nullable<int> WerkzameBeroepsbevolkingTotaal { get; set; }
        public Nullable<int> TotaalCreatieveBeroepen { get; set; }
        public Nullable<int> Kunsten { get; set; }
        public Nullable<int> MediaEnEntertainment { get; set; }
        public Nullable<int> CreatieveZakelijkeDienstverlening { get; set; }
        public Nullable<int> OverigeCreatieveBeroepen { get; set; }
        public Nullable<int> WerkzPersMetNietCreatieveBeroep { get; set; }
        public Nullable<int> WerkzPersMetBeroepOnbekend { get; set; }

        /// <summary>
        /// does conversion from the other object to this object.
        /// </summary>
        /// <param name="b">Database object</param>
        public static implicit operator WerkzameBeroepsBevolkingModel(ArrayOfWerkzameBeroepsbevolkingWerkzameBeroepsbevolking b)
        {
            WerkzameBeroepsBevolkingModel item = new WerkzameBeroepsBevolkingModel()
            {
                Id = b.Id,
                Kenmerken =  b.Kenmerken,
                Perioden =  b.Perioden,
                WerkzameBeroepsbevolkingTotaal = b.WerkzameBeroepsbevolkingTotaal,
                TotaalCreatieveBeroepen = b.TotaalCreatieveBeroepen,
                Kunsten = b.Kunsten,
                MediaEnEntertainment = b.MediaEnEntertainment,
                CreatieveZakelijkeDienstverlening = b.CreatieveZakelijkeDienstverlening,
                OverigeCreatieveBeroepen = b.OverigeCreatieveBeroepen,
                WerkzPersMetNietCreatieveBeroep = b.WerkzPersMetNietCreatieveBeroep,
                WerkzPersMetBeroepOnbekend = b.WerkzPersMetBeroepOnbekend
            };
            return item;
        }
    }
}
