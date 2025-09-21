using System.Windows;

namespace CampaignTracker.Features.Note;

/// <summary>
/// Interaction logic for NoteView.xaml
/// </summary>
public partial class NoteView
{
    public NoteView()
    {
        DataContext = this;
        InitializeComponent();
    }

    public NoteViewModel ViewModel
    {
        get { return (NoteViewModel)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }

    public object ItemsSource
    {
        get { return (object)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }

    // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(object), typeof(NoteView), new PropertyMetadata(null, ItemsSourcePropertyChanged));

    // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register("ViewModel", typeof(NoteViewModel), typeof(NoteView), new PropertyMetadata(new NoteViewModel()));


    private static void ItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(d is NoteView view)
        {
            view.ViewModel.Notes = e.NewValue as Models.NoteCollection;
        }
    }
}
