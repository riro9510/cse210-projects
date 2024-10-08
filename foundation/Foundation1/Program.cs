using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Random random = new Random();
        // Listas de nombres y comentarios para elegir aleatoriamente
        string[] titles = { "Video A", "Video B", "Video C", "Video D" };
        string[] authors = { "Author 1", "Author 2", "Author 3", "Author 4" };
        string[] comments = { "Great video!", "Very informative.", "Loved it!", "Not bad.", "Could be better.", "I learned a lot." };

        // Crear 4 videos de forma aleatoria
        for (int i = 0; i < 4; i++)
        {
            string title = titles[random.Next(titles.Length)];
            string author = authors[random.Next(authors.Length)];
            int lengthInSeconds = random.Next(200, 600); // Longitud aleatoria entre 200 y 600 segundos

            Video video = new Video(title, author, lengthInSeconds);

            // Agregar 3-4 comentarios aleatorios
            int commentCount = random.Next(3, 5); // 3 o 4 comentarios
            for (int j = 0; j < commentCount; j++)
            {
                string commenterName = $"User {random.Next(1, 100)}"; // Nombres de usuarios aleatorios
                string commentText = comments[random.Next(comments.Length)];
                video.AddComment(new Comment(commenterName, commentText));
            }

            // Agregar el video a la lista
            videos.Add(video);
        }

        // Mostrar información de cada video
        foreach (var video in videos)
        {
           video.printInfo();
        }
    }
}