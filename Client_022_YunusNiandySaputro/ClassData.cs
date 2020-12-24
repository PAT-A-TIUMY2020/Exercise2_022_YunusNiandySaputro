using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Client_022_YunusNiandySaputro
{
    class ClassData
    {
        string baseUrl = "http://localhost:1907/";

        public void insertMahasiswa(string nim, string nama, string prodi, string angkatan)
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.nama = nama;
            mhs.nim = nim;
            mhs.prodi = prodi;
            mhs.angkatan = angkatan;

            var data = JsonConvert.SerializeObject(mhs); //Convert to Json
            var postData = new WebClient();
            postData.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postData.UploadString(baseUrl + "CreateMahasiswa", data);
        }

        public Mahasiswa search(string nim)
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa/nim=" + nim);
            var data = JsonConvert.DeserializeObject<Mahasiswa>(json);
            return data;
        }

        public string sumData()
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            int i = data.Count();
            string sum = i.ToString();
            return sum;
        }

        public List<Mahasiswa> getAllData()
        {
            var json = new WebClient().DownloadString("http://localhost:1907/Mahasiswa");
            var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
            return data;
        }

        public bool updateDatabase(Mahasiswa mhs, string nim)
        {
            bool updated = false;
            try
            {
                List<Mahasiswa> data = getAllData();
                for (int i = 0; i <= data.Count() - 1; i++)
                {
                    if (data[i].nim == nim)
                    {
                        data[i] = mhs;

                        string output = JsonConvert.SerializeObject(mhs, Formatting.Indented);
                        WebClient postData = new WebClient();
                        postData.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        string response = postData.UploadString(baseUrl + "UpdateMahasiswaByNIM", output);
                        updated = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return updated;
        }

        public bool deleteMahasiswa(string nim)
        {
            bool deleted = false;
            try
            {
                var client = new RestClient(baseUrl);
                var request = new RestRequest("DeleteMahasiswa/" + nim, Method.DELETE);
                client.Execute(request);
            }
            catch (Exception ex)
            {

            }
            return deleted;
        }
    }
}

/*
 * 
 * List<Mahasiswa> data = getAllData();
                for (int i = 0; i <= data.Count() - 1; i++)
                {
                    if (data[i].nim == nim)
                    {
                        data.RemoveAt(i);

                        string output = JsonConvert.SerializeObject(data, Formatting.Indented);
                        WebClient postData = new WebClient();
                        postData.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                        string response = postData.UploadString(baseUrl + "DeleteMahasiswa", output);
                        deleted = true;
                    }
                }
 */
