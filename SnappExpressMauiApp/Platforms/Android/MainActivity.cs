using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace SnappExpressMauiApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private MBroadcastReceiver myreceiver;
    IntentFilter intentfilter;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
 
        myreceiver = new MBroadcastReceiver();
        intentfilter = new IntentFilter(Intent.ActionAirplaneModeChanged);
    }
    protected override void OnResume()
    {
        base.OnResume();
        RegisterReceiver(myreceiver, intentfilter);
    }
    [Android.Runtime.Register("OnPause()", "()V", "GetOnPauseHandler")]
    protected override void OnPause()
    {
        base.OnPause();
        UnregisterReceiver(myreceiver);
    }

    [BroadcastReceiver(Enabled = true)]
    public class MBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent i)
        {
            Toast.MakeText(context, "Received broadcast value received: " + i.Action,
                            ToastLength.Long).Show();
            Shell.Current.DisplayAlert("Airplane", "Action Air plane Mode Changed","Ok");
            //   Shell.Current.FindByName<Label>("lblText").Text = "Action Air plane Mode Changed" ;
        }
    }

}