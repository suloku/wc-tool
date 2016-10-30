/*
 * Created by SharpDevelop.
 * User: suloku
 * Date: 28/04/2016
 * Time: 21:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WC3_TOOL
{
	/// <summary>
	/// Description of FILEIO.
	/// </summary>
	public class FileIO
	{
			/// <summary>
			/// Reads data into a complete array, throwing an EndOfStreamException
			/// if the stream runs out of data first, or if an IOException
			/// naturally occurs.
			/// </summary>
			/// <param name="stream">The stream to read data from</param>
			/// <param name="data">The array to read bytes into. The array
			/// will be completely filled from the stream, so an appropriate
			/// size must be given.</param>
			private static void ReadWholeArray (Stream stream, ref byte[] data)
			{
			    int offset=0;
			    int remaining = data.Length;
			    while (remaining > 0)
			    {
			        int read = stream.Read(data, offset, remaining);
			        if (read <= 0)
			            throw new EndOfStreamException 
			                (String.Format("End of stream reached with {0} bytes left to read", remaining));
			        remaining -= read;
			        offset += read;
			    }
			}
			private static void _read_data(ref byte [] buffer, string path)
			{
		            System.IO.FileStream saveFile;
		            saveFile = new FileStream(path, FileMode.Open);
		            if (saveFile.Length < 1){
		            	MessageBox.Show("Invalid file length", "Error");
		            	return;
		            }
		            buffer = new byte[saveFile.Length];
		            //MessageBox.Show(buffer.Length.ToString());
		            ReadWholeArray(saveFile, ref buffer);
		            saveFile.Close();
		            return;
			}
			public static int load_file(ref byte[] buffer, ref string path, string filter)
	        {
				if (path == null)
				{
		            OpenFileDialog openFD = new OpenFileDialog();
		            //openFD.InitialDirectory = "c:\\";
		            openFD.Filter = filter;
		            DialogResult result = openFD.ShowDialog();
		            if ( result == DialogResult.OK)
		            {
		                #region filename
		                path = openFD.FileName;
		                //MessageBox.Show(path.ToString());
		                #endregion
		                _read_data(ref buffer, path);
		                //MessageBox.Show(buffer.Length.ToString());
		                return buffer.Length;
		            }else{
		            	return -1;
		            }
				}else
				{
		            _read_data(ref buffer, path);
		            //MessageBox.Show(buffer.Length.ToString());
		        	return buffer.Length;
				}
	            
	        }
			public static void save_data(byte[] buffer, string filter)
			{	//if (savegamename.Text.Length < 1) return;
				if (buffer == null) return;
	            SaveFileDialog saveFD = new SaveFileDialog();
	            //saveFD.InitialDirectory = "c:\\";
	            saveFD.Filter = filter;
	            if (saveFD.ShowDialog() == DialogResult.OK)
	            {
		            System.IO.FileStream saveFile;
		            saveFile = new FileStream(saveFD.FileName, FileMode.Create);            
		            //Write file
		            saveFile.Write(buffer, 0, buffer.Length);
		            saveFile.Close();
		            MessageBox.Show("File Saved.", "Save file");
	            }
			}
	}
}
