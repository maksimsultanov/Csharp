
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;

	private global::Gtk.Button btn_StartStop;

	private global::Gtk.Image image2;

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
		this.btn_StartStop = new global::Gtk.Button();
		this.btn_StartStop.CanFocus = true;
		this.btn_StartStop.Name = "btn_StartStop";
		this.btn_StartStop.UseUnderline = true;
		this.btn_StartStop.Label = global::Mono.Unix.Catalog.GetString("StartStop");
		this.fixed1.Add(this.btn_StartStop);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.btn_StartStop]));
		w1.X = 11;
		w1.Y = 21;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.image2 = new global::Gtk.Image();
		this.image2.Name = "image2";
		this.image2.Xpad = 640;
		this.image2.Ypad = 480;
		this.fixed1.Add(this.image2);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.image2]));
		w2.X = 19;
		w2.Y = 57;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 1918;
		this.DefaultHeight = 1638;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.btn_StartStop.Clicked += new global::System.EventHandler(this.btn_StartStop_Click);
	}
}