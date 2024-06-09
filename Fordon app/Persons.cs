using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_xl
{
    class Fordon
    {
        private string reggnummer;
        private int årsnummer;

        public Fordon() { }

        public Fordon(string reggnummer, int årsnummer)
        {
            this.reggnummer = reggnummer;
            this.årsnummer = årsnummer;
        }

        public string Registreringsnummer
        {
            get { return this.reggnummer; }
            set { this.reggnummer = value; }
        }

        public int Årsmodell
        {
            get { return this.årsnummer; }
            set { this.årsnummer = value; }
        }
    }

    class Bil : Fordon
    {
        private string bilmärke;

        public Bil(string reggnummer, int årsnummer, string bilmärke) : base(reggnummer, årsnummer)
        {
            this.BilMärke = bilmärke;
        }

        public string BilMärke
        {
            get { return this.bilmärke; }
            set { this.bilmärke = value; }
        }
    }
    class Mc : Fordon
    {
        private string mcTyp;

        public Mc(string reggnummer, int årsnummer, string mcTyp) : base(reggnummer, årsnummer)
        {
            this.McTyp = mcTyp;
        }

        public string McTyp
        {
            get { return this.mcTyp; }
            set { this.mcTyp = value; }
        }

    }
    class Lastbil : Fordon
    {
        private int lastbilsVikt;

        public Lastbil(string reggnummer, int årsnummer, int lastbilsVikt) : base(reggnummer, årsnummer)
        {
            this.LastbilsVikt = lastbilsVikt;
        }

        public int LastbilsVikt
        {
            get { return this.lastbilsVikt; }
            set { this.lastbilsVikt = value; }
        }
    }
}