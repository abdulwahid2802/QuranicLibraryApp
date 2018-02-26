using System;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ME.Itangqi.Waveloadingview;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using static Android.Icu.Text.MessageFormat;
using Calligraphy;
using Android.Runtime;
using Android.Graphics.Drawables;

namespace DesignLibrary_Tutorial
{
    [Activity(Label = "MainAct", MainLauncher = true, Theme = "@style/Theme.DesignDemo")]
    public class MainAct : AppCompatActivity
    {

        WaveLoadingView wlv;
        DrawerLayout mDrawerLayout;
        AppBarLayout appbar;
        AnimationDrawable animation;



        protected override void AttachBaseContext(Context newBase)
        {
            base.AttachBaseContext(CalligraphyContextWrapper.Wrap(newBase));
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main_1);

            

            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.Title = "";


            appbar = FindViewById<AppBarLayout>(Resource.Id.appbar);
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);
            appbar.LayoutParameters.Height = (int)(metrics.HeightPixels / 2);

            //animation = (AnimationDrawable)appbar.Background;
            //animation.SetEnterFadeDuration(5000);
            //animation.SetExitFadeDuration(2000);
            //animation.Start();
            


            
            FrameLayout btn_recite = FindViewById<FrameLayout>(Resource.Id.btn_recite);
            FrameLayout btn_listen = FindViewById<FrameLayout>(Resource.Id.btn_listen);
            FrameLayout btn_study = FindViewById<FrameLayout>(Resource.Id.btn_study);

            var width = metrics.WidthPixels;

            btn_recite.LayoutParameters.Width = (int)(width / 1.3);
            btn_listen.LayoutParameters.Width = (int)(width / 1.3);
            btn_study.LayoutParameters.Width = (int)(width / 1.3);


            CollapsingToolbarLayout collapsingToolBar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolBar.Title = "";

            wlv = FindViewById<WaveLoadingView>(Resource.Id.waveLoadingView);
            SetUpWaveLoading(wlv);
            

            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            //  set drawer width to 3 fourth of the screen size
            navigationView.LayoutParameters.Width = (int)(Resources.DisplayMetrics.WidthPixels * .75);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }



            //data = new DataManip(this);

            //dataPath = data.createDBconnection();
            //Toast.MakeText(this, dataPath, ToastLength.Long).Show();
            //Console.WriteLine(dataPath);

            //string dbCreateRes = data.createDatabase(dataPath);
            //Toast.MakeText(this, dbCreateRes, ToastLength.Long).Show();

            //LocalDB localDB = new LocalDB() { FirstName = "AbdulVohid", LastName = "ServenatOfAllah", ID = 16012686 };

            //string inserRes = await data.insertUpdateData(localDB, dataPath);
            //Toast.MakeText(this, inserRes, ToastLength.Long).Show();


            //System.IO.StreamReader streamReader = new System.IO.StreamReader(dataPath);
            //string db = streamReader.ReadToEnd();
            //Toast.MakeText(this, db, ToastLength.Long).Show();
            //Console.WriteLine(db);

        }

        private void SetUpWaveLoading(WaveLoadingView wlv)
        {
            wlv.ProgressValue = 50;
            wlv.SetAnimDuration(15000);
            wlv.SetAmplitudeRatio(35);

            wlv.CenterTitle = "Maghrib";
            wlv.TopTitle = "-2:25";
            wlv.BottomTitle = "12:35";
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }


        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected +=  (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_quran:
                        //Intent intent = new Intent(this, typeof(MainAct));
                        //StartActivity(intent);
                        e.MenuItem.SetChecked(true);
                        mDrawerLayout.CloseDrawers();
                        break;

                    //case Resource.Id.nav_hadith:
                        //LocalDB localDB = await data.Query(dataPath, 16012686);

                        //Console.WriteLine(localDB.LastName);
                        e.MenuItem.SetChecked(true);
                        mDrawerLayout.CloseDrawers();
                        break;

                    //case Resource.Id.nav_names:
                        e.MenuItem.SetChecked(true);
                        mDrawerLayout.CloseDrawers();

                        break;

                    default:
                        break;

                }
            };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.sample_actions, menu);
            return true;
        }

    }   
}