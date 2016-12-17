namespace TagsCloudApp.Core
{
	public class WordInfo
	{
		public readonly string Word;
		public readonly double Frequency;

		public WordInfo(string word, double frequency)
		{
			Word = word;
			Frequency = frequency;
		}

		private bool Equals(WordInfo other)
		{
			return string.Equals(Word, other.Word);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((WordInfo) obj);
		}

		public override int GetHashCode()
		{
			return Word?.GetHashCode() ?? 0;
		}

		public static bool operator ==(WordInfo left, WordInfo right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(WordInfo left, WordInfo right)
		{
			return !Equals(left, right);
		}
	}
}