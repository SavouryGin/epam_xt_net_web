namespace Task_2_2_Adventure
{
	class Program
	{
		/* Классический текстовый квест.
		 * Игрок должен правильно отвечать на вопросы,
		 * и использовать подобранные предметы,
		 * чтобы пройти игру до конца.
		 */
		static void Main(string[] args)
		{

			Game _Game = new Game();

			// Start
			while (_Game.isRunning)
			{
				_Game.Update();
			}

		}
	}
}
