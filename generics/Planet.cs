class Planet : ICSVFormat
    {
        string name;
        DateTime observed;

        public string Name
        {
            get => name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Planet name cannot be empty");
                }
            }
        }
        public DateTime Observed { 
            get => observed;
            set 
            {
                if (value > DateTime.Now)
                {
                    observed = value;
                }
                else
                {
                    observed = DateTime.Now;
                }
            } 
        }

        public Planet(string name, DateTime observed)
        {
            Name = name;
            Observed = observed;
        }

        public string CSVFormat(char separator = ';')
        {
            return $"{Name}{separator}{Observed}";
        }

        public override string ToString()
        {
            return $"{Name} - {Observed}";
        }

    }
