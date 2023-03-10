using System;
using System.Collections.Generic;

namespace VideoStore
{
	enum VideoFormat
	{
		DVD,
		Streaming,
		VHS
	}

	abstract class Video
	{
		// Try googling "C# abstract method"

		protected string Title;
		protected string Description;
		protected VideoFormat Format;
		protected decimal Price;

		public Video(string _Title, string _Description, VideoFormat _Format, decimal _Price)
		{
			Title = _Title;
			Description = _Description;
			Format = _Format;
			Price = _Price;
		}

		public override string ToString()
		{
			return $"{Title} {Description} {Format} {Price}";
		}
	}

	class VideoForRent : Video
	{
		protected int Condition;
		public VideoForRent(string _Title, string _Description, VideoFormat _Format,
			decimal _Price, int _Condition) : base(_Title, _Description, _Format, _Price)
		{
			Condition = _Condition;
		}

		public void Update(string _Title, string _Description, VideoFormat _Format,
			decimal _Price, int _Condition)
		{
			Title = _Title;
			Description = _Description;
			Format = _Format;
			Price = _Price;
			Condition = _Condition;
		}

		public override string ToString()
		{
			return $"(RENTAL) {base.ToString()} Condition: {Condition}";
		}
	}

	class VideoForPurchase : Video
	{
		protected int Points;
		public VideoForPurchase(string _Title, string _Description, VideoFormat _Format,
			decimal _Price, int _Points) : base(_Title, _Description, _Format, _Price)
		{
			Points = _Points;
		}
		public void Update(string _Title, string _Description, VideoFormat _Format,
			decimal _Price, int _Points)
		{
			Title = _Title;
			Description = _Description;
			Format = _Format;
			Price = _Price;
			Points = _Points;
		}

		public override string ToString()
		{
			return $"(PURCHASE) {base.ToString()} Points: {Points}";
		}
	}

	class VideoList
	{
		// Jeff will fill this in later
	}

	class Program
	{
		static void ListVideos(List<Video> TheList)
		{
			for (int index = 0; index < TheList.Count; index++)
			{
				Console.WriteLine($"{index + 1}. {TheList[index]}");
			}
		}

		// What tasks do we do?
		// Sell a video (which deletes it from the list)
		// Edit a video
		// Add a new video, either Rental or Purchase

		public static void Sell(List<Video> TheList, int index)
		{
			// "Delete" part of "CRUD"
			// This function deletes an instance from the list
			Console.WriteLine("Here is your video");
			Console.WriteLine(TheList[index]);
			Console.Write("Are you sure? (y/n) ");
			string entry = Console.ReadLine();
			if (entry == "y" || entry == "Y")
			{
				// They chose Y, so remove it from the list
				TheList.RemoveAt(index);
			}
		}

		public static void Add(List<Video> TheList)
		{
			// "Create" part of "CRUD"
			// This function creates a new instance of either VideoForPurchase or VideoForRent
			// and adds it to the list.
			//
			//
			//    The "real" steps:
			//        1. Gather up the fields (print out field name, ask them what they want, save it in a variable)
			//        2. Create an instance using those fields
			//        3. Add it to the list

			// Ask the user what type of video. That will determine the questions and the class to use
			Console.Write("Is this a video for (P)urchase or (R)ent? ");
			string entry = Console.ReadLine();

			//
			// Step 1. Gather the fields
			//
			//    Now ask for all the common stuff regardless of purchase or rental
			//
			Console.WriteLine("Please enter the details for this video:");

			Console.Write("Title: ");
			string _title = Console.ReadLine();

			Console.Write("Description: ");
			string _description = Console.ReadLine();

			// Ask for format, and pick the format based on what they entered using a switch statement.
			Console.Write("Format: ");
			string _formatStr = Console.ReadLine();
			VideoFormat _format = VideoFormat.DVD;
			switch (_formatStr) // Here's one way to convert a string to an enum
			{
				case "DVD":
					_format = VideoFormat.DVD;
					break;
				case "Streaming":
					_format = VideoFormat.Streaming;
					break;
				case "VHS":
					_format = VideoFormat.VHS;
					break;
			}

			Console.Write("Price: ");
			string _priceStr = Console.ReadLine();
			decimal _price = decimal.Parse(_priceStr); // Convert it to a decimal

			// Now do the specifics for purchase vs rental
			if (entry == "P")
			{
				// The user wants to create a video for purchase - create an instance of VideoForPurchase

				Console.Write("Points: ");
				string _pointsStr = Console.ReadLine();
				int _points = int.Parse(_pointsStr); // Convert it to an integer

				//
				// Step 2: Create the instance (VideoForPurchase version)
				//
				//      Now we have all the variables, so create the instance and add it to the list
				VideoForPurchase inst = new VideoForPurchase(_title, _description, _format, _price, _points);

				//
				// Step 3: Add it to the list
				//
				TheList.Add(inst);

			}
			else
			{
				// The user wants to create a video for rental - create an instance of VideoForRent
				Console.Write("Condition: ");
				string _conditionStr = Console.ReadLine();
				int _condition = int.Parse(_conditionStr);

				//
				// Step 2: Create the instance (VideoForRent version)
				//
				VideoForRent inst = new VideoForRent(_title, _description, _format, _price, _condition);
				//
				// Step 3: Add it to the list
				//
				TheList.Add(inst);
			}

		}

		static void Edit(List<Video> TheList, int index)
		{
			// 1. Grab the one they're requesting.
			// 2. Go through the common fields and print out the current value,
			//    and ask for the new value, and store it in a variable
			// 3. Call the Update function for the object

			Video myvideo = TheList[index];
			Console.WriteLine("Here is the one you're modifying:");
			Console.WriteLine(myvideo);

			//
			// Common fields first
			//
			Console.Write("Title: ");
			string _title = Console.ReadLine();

			Console.Write("Description: ");
			string _description = Console.ReadLine();

			// Ask for format, and pick the format based on what they entered using a switch statement.
			Console.Write("Format: ");
			string _formatStr = Console.ReadLine();
			VideoFormat _format = VideoFormat.DVD;
			switch (_formatStr) // Here's one way to convert a string to an enum
			{
				case "DVD":
					_format = VideoFormat.DVD;
					break;
				case "Streaming":
					_format = VideoFormat.Streaming;
					break;
				case "VHS":
					_format = VideoFormat.VHS;
					break;
			}

			Console.Write("Price: ");
			string _priceStr = Console.ReadLine();
			decimal _price = decimal.Parse(_priceStr); // Convert it to a decimal


			if (myvideo is VideoForPurchase)
			{
				VideoForPurchase vp = myvideo as VideoForPurchase;
				Console.Write("Points: ");
				string _pointsStr = Console.ReadLine();
				int _points = int.Parse(_pointsStr); // Convert it to an integer
				vp.Update(_title, _description, _format, _price, _points);
			}
			else
			{
				VideoForRent vr = myvideo as VideoForRent;
				Console.Write("Condition: ");
				string _conditionStr = Console.ReadLine();
				int _condition = int.Parse(_conditionStr);
				vr.Update(_title, _description, _format, _price, _condition);
			}
		}

		static void Main(string[] args)
		{
			List<Video> AllVideos = new List<Video>();

			Video myvideo;

			myvideo = new VideoForPurchase("Star Wars", "Luke Destroys Death Star", VideoFormat.VHS, 15.00m, 10);
			AllVideos.Add(myvideo);
			myvideo = new VideoForPurchase("Harry Potter", "Harry Learns Wizardry", VideoFormat.DVD, 20.00m, 8);
			AllVideos.Add(myvideo);
			myvideo = new VideoForRent("Die Hard", "Guys take over a building", VideoFormat.Streaming, 6.00m, 3);
			AllVideos.Add(myvideo);
			myvideo = new VideoForRent("Jurassic Park", "Dinosaurs Everywhere", VideoFormat.DVD, 8.00m, 4);
			AllVideos.Add(myvideo);

			while (true)
			{
				Console.WriteLine("Here's our current stock:");
				ListVideos(AllVideos);
				Console.Write("Please choose one or (A)dd (E)dit (Q)uit: ");
				string entry = Console.ReadLine();
				if (entry == "A")
				{
					Add(AllVideos);
				}
				else if (entry == "E")
				{
					Console.WriteLine("Which one would you like to edit?");
					string which = Console.ReadLine();
					int index = int.Parse(which);
					Edit(AllVideos, index - 1);
				}
				else if (entry == "Q")
				{
					break;
				}
				else
				{
					int index = int.Parse(entry);
					Sell(AllVideos, index - 1);
				}
			}


            // ALL THIS BELOW IS TEST/SCRATCHPAD CODE!

            //Edit(AllVideos, 1);
            //Console.WriteLine("Here's our stock after editing:");
            //ListVideos(AllVideos);

            //Console.Write("Please choose one or (A)dd (E)dit (Q)uit: ");
            //string entry = Console.ReadLine();

            //This code tests the Sell function

            Sell(AllVideos, 1);
            Console.WriteLine("After we sold index 1");
            ListVideos(AllVideos);

            // Test of our ToString functions
            //Video v1 = new Video("Video1", "Test of Video class", VideoFormat.DVD, 10.00m);
            //Console.WriteLine(v1);

            //VideoForRent v2 = new VideoForRent("Video2", "Test of VideoForRent",
            //	VideoFormat.VHS, 15.00m, 5);
            //Console.WriteLine(v2);

            //string test2 = v2.ToString();
            //Console.WriteLine(test2);

            // Practice string insertions similar to how we're doing our ToString calls
            //string s1 = "World";
            //string s2 = $"Hello {GetString()}!";
            //Console.WriteLine(s2);
            //string s3 = $"Hello {s1}!";
            //Console.WriteLine(s3);
        }
	}
}
