using BookApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BookApi.Services
{
    public class JobpostService
    {
        private readonly IMongoCollection<JobPost> _jobPost;

        public JobpostService(IJobPostDatabseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _jobPost = database.GetCollection<JobPost>(settings.JobpostCollectionName);
        }

        public List<JobPost> Get() =>
            _jobPost.Find(jobPost => true).ToList();

        public JobPost Get(string id) =>
            _jobPost.Find<JobPost>(jobPost => jobPost.Id == id).FirstOrDefault();

        public JobPost Create(JobPost job)
        {
            _jobPost.InsertOne(job);
            return job;
        }

        public void Update(string id, JobPost job) =>
            _jobPost.ReplaceOne(job => job.Id == id, job);

        public void Remove(JobPost job) =>
           _jobPost.DeleteOne(job => job.Id == job.Id);

        public void Remove(string id) =>
            _jobPost.DeleteOne(job => job.Id == id);
    }
}
