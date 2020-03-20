private void egySzalAraTXTBX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))   // the ASCII backspace is 8
            {
                e.Handled = true;
            }
        }
        
