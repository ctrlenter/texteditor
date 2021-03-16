using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Core;
using TextEditor.Testing;

namespace TextEditor
{

    static class Program
    {

        //TODO: Fix ctrl + w bug. Den lukker flere tabs ved et klik.

        public static Mutex mutex = new Mutex ( true , "Text Editor" );

        static string [ ] getListOfParams ( string [ ] args )
        {
            string joinedArgs = string.Join ( " " , args );
            Logger.Log ( joinedArgs );
            string [ ] savedArgs = new string [ args.Length + 1 ];
            int j = 0;
            bool first = false;

            for ( int k = 0 ; k < savedArgs.Length ; k++ )
            {
                savedArgs [ k ] = "";
            }

            for ( int i = 0 ; i < joinedArgs.Length ; i++ )
            {
                savedArgs [ j ] += joinedArgs [ i ];
                if ( joinedArgs [ i ] == ':' )
                {
                    if ( first == true )
                    {
                        j += 1;
                        savedArgs [ j ] = savedArgs [ j - 1 ].Substring ( savedArgs [ j - 1 ].Length - 2 , 2 );
                        savedArgs [ j - 1 ] = savedArgs [ j - 1 ].Remove ( savedArgs [ j - 1 ].Length - 3 , 3 );
                    }
                    else
                    {
                        first = true;
                    }
                }
                else if ( joinedArgs [ i ] == '.' )
                {
                    //then we can check if i + 1 is out of bounds
                    if ( i + 1 > joinedArgs.Length ) continue;
                    else
                    {
                        if ( joinedArgs [ i + 1 ] == '/' )
                        {
                            if ( first )
                            {
                                j += 1;
                                console.log ( savedArgs [ j - 1 ].Substring ( savedArgs [ j - 1 ].Length - 1 , 1 ) );
                                savedArgs [ j ] = savedArgs [ j - 1 ].Substring ( savedArgs [ j - 1 ].Length - 1 , 1 );
                                savedArgs [ j - 1 ] = savedArgs [ j - 1 ].Remove ( savedArgs [ j - 1 ].Length - 2 , 2 );

                            }
                            else
                            {
                                first = true;
                            }
                        }
                    }
                }
            }

            return savedArgs;
        }

        [STAThread]
        static void Main ( string [ ] args )
        {

            Application.EnableVisualStyles ( );
            Application.SetCompatibleTextRenderingDefault ( false );
            Form1 mainForm = new Form1 ( );

            if ( Form1.Config [ "tabsInNewInstance" ].ToLower ( ) == "true" )
            {
                try
                {
                    var savedArgs = getListOfParams ( args );

                    if ( savedArgs.Length > 1 )
                    {
                        foreach ( string s in savedArgs )
                        {
                            if ( s != null )
                            {
                                if ( !s.Contains ( ".exe" ) )
                                {
                                    if ( !string.IsNullOrEmpty ( s ) )
                                    {
                                        if ( File.Exists ( s ) )
                                        {
                                            mainForm.AddTab ( Path.GetFullPath ( s ) );
                                            Utils.FlashWindowEx ( mainForm );
                                        }
                                        else
                                            console.log ( "Skipped" );
                                        continue;
                                    }
                                }
                            }
                        }
                        if ( mainForm.tabs.TabCount == 0 )
                        {
                            mainForm.AddTab ( );
                        }
                    }
                    else
                    {
                        mainForm.AddTab ( );
                    }



                    Application.Run ( mainForm );
                }
                catch ( Exception ex )
                {
                    MessageBox.Show ( ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace );
                }
            }
            else
            {
                if ( mutex.WaitOne ( TimeSpan.Zero , false ) )
                {
                    try
                    {
                        var savedArgs = getListOfParams ( args );

                        if ( savedArgs.Length > 1 )
                        {
                            foreach ( string s in savedArgs )
                            {
                                if ( s != null )
                                {
                                    if ( !s.Contains ( ".exe" ) )
                                    {
                                        if ( !string.IsNullOrEmpty ( s ) )
                                        {
                                            if ( File.Exists ( s ) )
                                            {
                                                mainForm.AddTab ( Path.GetFullPath ( s ) );
                                                Utils.FlashWindowEx ( mainForm );
                                            }
                                            else
                                                console.log ( "Skipped" );
                                            continue;
                                        }
                                    }
                                }
                            }
                            if ( mainForm.tabs.TabCount == 0 )
                            {
                                mainForm.AddTab ( );
                            }
                        }
                        else
                        {
                            mainForm.AddTab ( );
                        }

                        Application.Run ( mainForm );
                    }
                    catch ( Exception ex )
                    {
                        MessageBox.Show ( ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace );
                    }

                    mutex.ReleaseMutex ( );

                }
                else
                {
                    var savedArgs = getListOfParams ( args );
                    if ( savedArgs.Length > 1 )
                    {
                        foreach ( string s in savedArgs )
                        {
                            if ( s != null )
                            {
                                if ( !s.Contains ( ".exe" ) )
                                {
                                    if ( !string.IsNullOrEmpty ( s ) )
                                    {
                                        if ( File.Exists ( s ) )
                                            Form1.AddTabMessage ( s );
                                        continue;
                                    }
                                }
                            }
                        }

                    }



                }

            }
        }

    }

}
