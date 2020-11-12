using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace XamlBrewer.UWP.MvvmToolkit.Sample.Models
{
    public class StudyGroup : ObservableValidator
    {
        private string _topic = string.Empty;
        private string _hobbies;
        private int _class = 2009;

        public StudyGroup()
        {
            this.ErrorsChanged += StudyGroup_ErrorsChanged;

            this.PropertyChanged += StudyGroup_PropertyChanged;

            // Validate current state.
            SetProperty(ref _topic, _topic, true, nameof(Topic));

            // Validates and returns a boolean. Does not assign the value.
            // Validator.TryValidateProperty(_topic, new ValidationContext(this, null, null) { MemberName = nameof(Topic) }, null);

            // Validates, and throws an exception if not valid.
            // Validator.ValidateProperty(_topic, new ValidationContext(this, null, null) { MemberName = nameof(Topic) });
        }

        [Required(ErrorMessage = "Topic is Required")]
        [MinLength(2, ErrorMessage = "Topic should be longer than one character")]
        public string Topic
        {
            get => _topic;
            set => SetProperty(ref _topic, value, true);
        }

        [Range(2009, 2015, ErrorMessage = "Class should be from 2009 to 2015")]
        public int Class
        {
            get => _class;
            set => SetProperty(ref _class, value, true);
        }

        [RegularExpression(@".*[pP]aintball.*", ErrorMessage = "Hobbies should contain 'Paintball'.")]
        public string Hobbies
        {
            get => _hobbies;
            set => SetProperty(ref _hobbies, value, true);
        }

        public string Errors => string.Join(Environment.NewLine, from ValidationResult e in GetErrors(null) select e.ErrorMessage);

        private void StudyGroup_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(HasErrors))
            {
                OnPropertyChanged(nameof(HasErrors)); // Update HasErrors on every change, so I can bind to it.
            }
        }

        private void StudyGroup_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Errors)); // Update Errors on every Error change, so I can bind to it.
        }
    }
}
