using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Services.Dialogs
{
    /// <summary>
    /// Provides elementary Modal View services: display message, request confirmation, request input.
    /// </summary>
    public class ModalView    {
        /// <summary>
        /// Opens a modal message dialog.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public async Task MessageDialogAsync(string title, string message)
        {
            await MessageDialogAsync(title, message, "OK");
        }

        /// <summary>
        /// Opens a modal message dialog.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="buttonText">The button text.</param>
        /// <returns>Task.</returns>
        public async Task MessageDialogAsync(string title, string message, string buttonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = buttonText
            };

            await dialog.ShowAsync();
        }

        /// <summary>
        /// Opens a modal confirmation dialog.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Task&lt;System.Nullable&lt;System.Boolean&gt;&gt;.</returns>
        public async Task<bool?> ConfirmationDialogAsync(string title)
        {
            return await ConfirmationDialogAsync(title, "OK", string.Empty, "Cancel");
        }

        /// <summary>
        /// Opens a modal confirmation dialog.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="yesButtonText">The 'Yes' button text.</param>
        /// <param name="noButtonText">The 'No' button text.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> ConfirmationDialogAsync(string title, string yesButtonText, string noButtonText)
        {
            return (await ConfirmationDialogAsync(title, yesButtonText, noButtonText, string.Empty)).Value;
        }

        /// <summary>
        /// Opens a modal confirmation dialog.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="yesButtonText">The 'Yes' button text.</param>
        /// <param name="noButtonText">The 'No' button text.</param>
        /// <param name="cancelButtonText">The cancel button text.</param>
        /// <returns>Task&lt;System.Nullable&lt;System.Boolean&gt;&gt;.</returns>
        public async Task<bool?> ConfirmationDialogAsync(string title, string yesButtonText, string noButtonText, string cancelButtonText)
        {
            var dialog = new ContentDialog
            {
                Title = title,
                //IsPrimaryButtonEnabled = true,
                PrimaryButtonText = yesButtonText,
                //IsSecondaryButtonEnabled = true,
                SecondaryButtonText = noButtonText,
                CloseButtonText = cancelButtonText
            };
            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.None)
            {
                return null;
            }

            return (result == ContentDialogResult.Primary);
        }

        /// <summary>
        /// Opens a modal input dialog for a string.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> InputStringDialogAsync(string title)
        {
            return await InputStringDialogAsync(title, string.Empty);
        }

        /// <summary>
        /// Opens a modal input dialog for a string.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="defaultText">The default response text.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> InputStringDialogAsync(string title, string defaultText)
        {
            return await InputStringDialogAsync(title, defaultText, "OK", "Cancel");
        }

        /// <summary>
        /// Opens a modal input dialog for a string.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="defaultText">The default response text.</param>
        /// <param name="okButtonText">The 'OK' button text.</param>
        /// <param name="cancelButtonText">The 'Cancel' button text.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> InputStringDialogAsync(string title, string defaultText, string okButtonText, string cancelButtonText)
        {
            var inputTextBox = new TextBox
            {
                AcceptsReturn = false,
                Height = 32,
                Text = defaultText,
                SelectionStart = defaultText.Length
            };
            var dialog = new ContentDialog
            {
                Content = inputTextBox,
                Title = title,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = okButtonText,
                SecondaryButtonText = cancelButtonText
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                return inputTextBox.Text;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Opens a modal input dialog for a multi-line text.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> InputTextDialogAsync(string title)
        {
            return await InputTextDialogAsync(title, string.Empty);
        }

        /// <summary>
        /// Opens a modal input dialog for a multi-line text.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="defaultText">The default text.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> InputTextDialogAsync(string title, string defaultText)
        {
            return await InputTextDialogAsync(title, defaultText, "OK", "Cancel");
        }

        /// <summary>
        /// Opens a modal input dialog for a multi-line text.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="defaultText">The default text.</param>
        /// <param name="okButtonText">The 'OK' button text.</param>
        /// <param name="cancelButtonText">The 'Cancel' button text.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> InputTextDialogAsync(string title, string defaultText, string okButtonText, string cancelButtonText)
        {
            var inputTextBox = new TextBox
            {
                AcceptsReturn = true,
                Height = 32 * 6,
                Text = defaultText,
                TextWrapping = TextWrapping.Wrap,
                SelectionStart = defaultText.Length,
                Opacity = 1,
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush((Color)Application.Current.Resources["CustomDialogBorderColor"])
            };
            var dialog = new ContentDialog
            {
                Content = inputTextBox,
                Title = title,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = okButtonText,
                SecondaryButtonText = cancelButtonText
            };

            if (await dialog.ShowAsync() == ContentDialogResult.Primary)
            {
                return inputTextBox.Text;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
