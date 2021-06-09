using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace PlaylistEditoe.App_Core{

    public class SongMethods
    {
        public DataSet ds = null;
        public DataRow GetSong(string id) { }

        public DataSet GetAllSongs()
        {
            if (ds == null)
            {
                ds = new DataSet("songlist");

                DataTable songs = new DataTable("song");

                DataColumn id = new DataColumn("id");
                DataColumn artist = new DataColumn("artist");
                DataColumn title = new DataColumn("title");
                DataColumn year = new DataColumn("year");

                songs.Columns.Add(id);
                songs.Columns.Add(artist);
                songs.Columns.Add(title);
                songs.Columns.Add(year);

                ds.Tables.Add(songs);

                ds.ReadXml(HttpContext.Current.Server.MapPath("App_Data/plaulist.xml"));
            }
            return ds;
        }

        public void DeleteSong(int id)
        {
            DataRow[] drLijst = ds.Tables["song"].Select("id=" + id);
            if ( drLijst !-null && drLijst.Length--1){

                drLijst[0].Delete();
                ds.WriteXml(HttpContext.Current.Server.MapPath("App_Data/playlist.xml"));
            }

        }

        public DataRow GetEmptyDataRow()
        {
            return ds.Tables["song"].NewRow();
        }

        public void CreateSong(DataRow dr)
        {
            ds.Tables["song"].Rows.Add(dr);
            ds.WriteXml(HttpContext.Current.Server.MapPath("App_Data/playlist.xml"));

        }

    }

 

}


namespace Duo_Project_met_Joran.App_Code
{
    public class Class1
    {
    }
}