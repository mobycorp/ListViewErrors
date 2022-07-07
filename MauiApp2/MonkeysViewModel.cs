using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp2;

public class MonkeysViewModel : INotifyPropertyChanged {

	public MonkeysViewModel () {

		Monkeys.Add (new Monkey { Name = "Steve" });
		Monkeys.Add (new Monkey { Name = "Bill" });
		Monkeys.Add (new Monkey { Name = "Tom" });
		Monkeys.Add (new Monkey { Name = "Dick" });
		Monkeys.Add (new Monkey { Name = "Harry" });

		SelectedMonkeyCv = Monkeys.Skip (3).FirstOrDefault ();
		SelectedMonkeyLv = Monkeys.Skip (2).FirstOrDefault ();
	}

	public ObservableCollection<Monkey> Monkeys { get; private set; } = new ObservableCollection<Monkey> ();

	public int CvHits { get; set; }
	public int LvHits { get; set; }

	Monkey selectedMonkeyCv;
	Monkey selectedMonkeyLv;

	public event PropertyChangedEventHandler PropertyChanged;

	public Monkey SelectedMonkeyCv {
		get => selectedMonkeyCv;
		set {
			if (selectedMonkeyCv != value) {
				++CvHits;

				selectedMonkeyCv = value;
			}

			OnPropertyChanged (nameof (SelectedMonkeyCv));
			OnPropertyChanged (nameof (CvHits));
		}
	}

	public Monkey SelectedMonkeyLv {
		get => selectedMonkeyLv;
		set {
			if (selectedMonkeyLv != value) {
				++LvHits;

				selectedMonkeyLv = value;
			}

			OnPropertyChanged (nameof (SelectedMonkeyLv));
			OnPropertyChanged (nameof (LvHits));
		}
	}

	void OnPropertyChanged (string name) => PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (name));
}