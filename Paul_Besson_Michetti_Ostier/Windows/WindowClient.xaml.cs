using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Paul_Besson_Michetti_Ostier.Classes;

namespace Paul_Besson_Michetti_Ostier.Windows
{
    public partial class WindowClient : Window
    {
        public WindowClient(Client unClient)
        {
            InitializeComponent();
            this.DataContext = unClient; 
        }

        /// <summary>
        /// Action de validation du formulaire[cite: 6]
        /// </summary>
        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;

       
            foreach (Object control in panelFormClient.Children)
            {
                if (control is TextBox)
                {
                    TextBox txt = (TextBox)control;

             
                    BindingExpression binding = txt.GetBindingExpression(TextBox.TextProperty);

                    if (binding != null)
                    {
                        try
                        {
    
                            binding.UpdateSource();
                        }
                        catch (ArgumentException ex)
                        {

                            ValidationError validationError = new ValidationError(new ExceptionValidationRule(), binding);
                            validationError.ErrorContent = ex.Message;

                           
                            Validation.MarkInvalid(binding, validationError);
                        }
                    }

                    if (Validation.GetHasError(txt))
                    {
                        ok = false;
                    }
                }
            }

           
            if (ok)
            {
                DialogResult = true; 
            }
            else
            {
                MessageBox.Show("Veuillez corriger les erreurs de saisie avant de valider.",
                                "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult = false;
        }
    }
}