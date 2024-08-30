namespace BankApp.Controls
{
    public class IntegerTextBox : TextBox
    {
        private bool nonNumberEntered = false;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }

            // If shift key was pressed, it's not a number.
            if (ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (nonNumberEntered)
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }
    }
}
