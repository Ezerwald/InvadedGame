using System.Collections;


namespace InvadedGame.Game.Actions
{
    public class ActionQueue<T> : IEnumerable<T> where T : GameAction
    {
        private readonly List<T> actions = new();
        private int version = 0;

        public void Enqueue(T action)
        {
            actions.Add(action);
            version++;
        }

        public T? Dequeue()
        {
            if (actions.Count == 0)
                return null;

            T action = actions[0];
            actions.RemoveAt(0);
            version++;
            return action;
        }

        public int Count => actions.Count;

        public IEnumerator<T> GetEnumerator()
            => new ActionQueueEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private class ActionQueueEnumerator : IEnumerator<T>
        {
            private readonly ActionQueue<T> queue;
            private readonly int initialVersion;
            private int index = -1;

            public ActionQueueEnumerator(ActionQueue<T> queue)
            {
                this.queue = queue;
                initialVersion = queue.version;
            }

            public T Current => queue.actions[index];
            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (initialVersion != queue.version)
                    throw new InvalidOperationException("Collection modified during iteration");

                index++;
                return index < queue.actions.Count;
            }

            public void Reset() => index = -1;
            public void Dispose() { }
        }
    }
}
