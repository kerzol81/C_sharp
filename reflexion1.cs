        public IllnessFrm()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetValues(typeof(IllnessType));
            comboBox2.DataSource = Enum.GetValues(typeof(IllnessCourse));
        }
