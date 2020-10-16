using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UWDownloader
{
    public class VO
    {
        //url contains the link to the server which stores the files
        private String url = "https://bbb-scale.univie.ac.at/presentation/";
        private String name = "";
        private String id = "";

        public VO(String id, String name)
            {
                this.id = id;
                this.name = name;
            }

        public String getid()
        {
            return this.id;
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        //functions for generating links to videos
        public String getCam()
        {
            return url + id + "/video/webcams.webm";
        }

        public String getScreen()
        {
            return url + id + "/deskshare/deskshare.webm";
        }
    }
}
