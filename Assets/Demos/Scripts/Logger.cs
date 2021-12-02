using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Logger
{
	private StreamWriter m_Writer = null;

	public Logger(string file_name)
	{
    #if UNITY_EDITOR || UNITY_STANDALONE
            string path = System.IO.Directory.GetCurrentDirectory() + "/Log";
            try
            {
            	if( false == Directory.Exists( path ) )
            	{
            		Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "/Log");
            	}
            }
            catch( Exception e )
            {
            	Debug.Log( e );
            }


            string file_path    = path + "/" + file_name;

            try
            {
                // // if you want not to recreate the same file every time, comment out the following line
            	// if( false == File.Exists( file_path ) )
            	{
            		FileStream fstream = File.Create( file_path );
            		fstream.Close();
            	}
            }
            catch( Exception e )
            {
            	Debug.Log( e );
            }

            try
            {
            	this.m_Writer = new StreamWriter( file_path, true, System.Text.Encoding.UTF8 );
            }
            catch( Exception e )
            {
            	Debug.Log( e );
            }
    #endif
        }

        public void Log( string message )
        {
           // Debug.Log( message );

    #if UNITY_EDITOR || UNITY_STANDALONE
    		m_Writer.WriteLine( message );
    		m_Writer.Flush();
    #endif
        }

        public void Close()
        {
        #if UNITY_EDITOR || UNITY_STANDALONE
        		m_Writer.Close();
        		m_Writer.Dispose();
        #endif
        }
    }
