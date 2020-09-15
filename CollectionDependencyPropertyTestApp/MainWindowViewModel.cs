using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CollectionDependencyPropertyTestApp
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Random _random = new Random();
        private ObservableCollection<string> _strings = new ObservableCollection<string>(); 
        public ObservableCollection<string> Strings { get => _strings; set { Set(() => Strings, ref _strings, value); }}
        
        private RelayCommand _changeStringsCmd;
        public RelayCommand ChangeStringsCmd => _changeStringsCmd ?? (_changeStringsCmd = new RelayCommand(
            () => changeStrings(),
            () => { return 1 == 1; },
			keepTargetAlive:true
            ));
		private void changeStrings()
        {
            Strings.Clear();
            int numStrings = _random.Next(1, 10);
            for (int i=1; i<=numStrings;i++)
            {
                Strings.Add($"#{i}: {DateTime.Now}");
            }
        }


    }
}
