using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeekQuiz.Models;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http.Description;

namespace HOLApp1.Controllers
{
    public class TriviaController : ApiController
    {
        private TriviaContext db = new TriviaContext();

        private async Task<TriviaQuestion> NextQuestionAsync(string userId)
        {
            var lastQuestionId =  this.db.TriviaAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => new { q.Count, QuestionId = q.QuestionId })
                .Select(q => q.QuestionId)
                .FirstOrDefault();

            var questionsCount = this.db.TriviaQuestions.Count();
            var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            return await this.db.TriviaQuestions.FindAsync(CancellationToken.None, nextQuestionId);

        }

        [ResponseType(typeof(TriviaQuestion))]
        public async Task<IHttpActionResult> Get()
        {
            var userId = User.Identity.Name;
            TriviaQuestion nextQuestion = await this.NextQuestionAsync(userId);
            if (nextQuestion == null)
            {
                return this.NotFound();
            }
            return this.Ok(nextQuestion);
        }

        private async Task<bool> StoreAsync(TriviaAnswer answer)
        {
            this.db.TriviaAnswers.Add(answer);
            await this.db.SaveChangesAsync();
            var selectedOption = this.db.TriviaOptions.FirstOrDefault(o => o.Id == answer.OptionId && o.QuestionId == answer.QuestionId);
            return selectedOption.IsCorrect;
        }

        [ResponseType(typeof(TriviaAnswer))]
        public async Task<IHttpActionResult> Post(TriviaAnswer answer)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            answer.UserId = User.Identity.Name;
            var isCorrect = await this.StoreAsync(answer);
            return this.Ok<bool>(isCorrect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                this.db.Dispose();  
            }
            base.Dispose(disposing);
        }




    }
}
