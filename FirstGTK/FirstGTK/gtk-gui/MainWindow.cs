
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;

	private global::Gtk.Entry entry1;

	private global::Gtk.Entry entry2;

	private global::Gtk.Entry entry3;

	private global::Gtk.Button button3;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.entry1 = new global::Gtk.Entry();
		this.entry1.CanFocus = true;
		this.entry1.Name = "entry1";
		this.entry1.IsEditable = true;
		this.entry1.InvisibleChar = '•';
		this.fixed1.Add(this.entry1);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry1]));
		w1.X = 23;
		w1.Y = 59;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.entry2 = new global::Gtk.Entry();
		this.entry2.CanFocus = true;
		this.entry2.Name = "entry2";
		this.entry2.IsEditable = true;
		this.entry2.InvisibleChar = '•';
		this.fixed1.Add(this.entry2);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry2]));
		w2.X = 340;
		w2.Y = 64;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.entry3 = new global::Gtk.Entry();
		this.entry3.CanFocus = true;
		this.entry3.Name = "entry3";
		this.entry3.IsEditable = true;
		this.entry3.InvisibleChar = '•';
		this.fixed1.Add(this.entry3);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry3]));
		w3.X = 341;
		w3.Y = 106;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.button3 = new global::Gtk.Button();
		this.button3.CanFocus = true;
		this.button3.Name = "button3";
		this.button3.UseUnderline = true;
		this.button3.Label = global::Mono.Unix.Catalog.GetString("GtkButton");
		this.fixed1.Add(this.button3);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button3]));
		w4.X = 72;
		w4.Y = 107;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 556;
		this.DefaultHeight = 300;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.button3.Clicked += new global::System.EventHandler(this.click);
	}
}
