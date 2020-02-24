private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) // BackSpace --> ASCII 8
            {
                        e.Handled = true;
            }
        }
