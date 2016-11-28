using System;
using System.Collections.Generic;
using System.Text;
using DM.MovieApi;


namespace HelloWorld.iOS
{
    using CoreGraphics;

    using UIKit;
    public class MyViewController : UIViewController
    {
        private const int HorizontalMargin = 20;

        private const int StartY = 80;

        private const int StepY = 50;

        private int _yCoord;

        public MyViewController()
        {
            MovieDbFactory.RegisterSettings(new MyClass());
        }
            
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.White;

            this._yCoord = StartY;

            var prompt = new UILabel()
                             {
                                 Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width, 50),
                                 Text = "Enter words in movie title: "
                             };
            this._yCoord += StepY;

            var nameField = new UITextField()
                                {
                                    Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width - 2*HorizontalMargin, 50),
                                    BorderStyle = UITextBorderStyle.RoundedRect,
                                    Placeholder = "Movie title"
                                };
            this._yCoord += StepY;

            var greetingButton = UIButton.FromType(UIButtonType.RoundedRect);
            greetingButton.Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width - 2 * HorizontalMargin, 50);
            greetingButton.SetTitle("Get movie", UIControlState.Normal);
            this._yCoord += StepY;

            var greetingLabel = new UILabel()
                                    {
                                        Frame = new CGRect(HorizontalMargin, this._yCoord, this.View.Bounds.Width, 50)    
                                    };
            this._yCoord += StepY;

            


            greetingButton.TouchUpInside += (sender, args) =>
                {
                    nameField.ResignFirstResponder();
                    //url += nameField.Text;
                    GetMovies(nameField.Text);
                    
                    //greetingLabel.Text =  results from query
                };

            this.View.AddSubview(prompt);
            this.View.AddSubview(nameField);
            this.View.AddSubview(greetingButton);
            this.View.AddSubview(greetingLabel);
        }

        public async void GetMovies(string query)
        {
            var movieApi = MovieDbFactory.Create<DM.MovieApi.MovieDb.Movies.IApiMovieRequest>().Value;

            DM.MovieApi.ApiResponse.ApiSearchResponse<DM.MovieApi.MovieDb.Movies.MovieInfo> response = await movieApi.SearchByTitleAsync(query);

            foreach (DM.MovieApi.MovieDb.Movies.MovieInfo info in response.Results)
            {
                Console.WriteLine("{0} ({1}): {2}", info.Title, info.ReleaseDate, info.Overview);
            }

        }
    }
}
