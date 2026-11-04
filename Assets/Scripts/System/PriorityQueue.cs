using System;
using System.Collections.Generic;
//Created by gemini, this project simply doesnt support what was provided in the example code so it is added here
public class PriorityQueue<TElement, TPriority>
{
    private readonly List<(TElement Element, TPriority Priority)> _nodes = new List<(TElement, TPriority)>();
    private readonly IComparer<TPriority> _comparer;

    public PriorityQueue() : this(null) { }

    public PriorityQueue(IComparer<TPriority> comparer)
    {
        _comparer = comparer ?? Comparer<TPriority>.Default;
    }

    public int Count => _nodes.Count;

    public void Enqueue(TElement element, TPriority priority)
    {
        _nodes.Add((element, priority));
        int ci = _nodes.Count - 1;
        while (ci > 0)
        {
            int pi = (ci - 1) / 2;
            if (_comparer.Compare(_nodes[ci].Priority, _nodes[pi].Priority) >= 0)
                break;
            var tmp = _nodes[ci];
            _nodes[ci] = _nodes[pi];
            _nodes[pi] = tmp;
            ci = pi;
        }
    }

    public TElement Dequeue()
    {
        if (_nodes.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int li = _nodes.Count - 1;
        TElement frontItem = _nodes[0].Element;
        _nodes[0] = _nodes[li];
        _nodes.RemoveAt(li);

        --li;
        int pi = 0;
        while (true)
        {
            int ci = pi * 2 + 1;
            if (ci > li) break;
            int rc = ci + 1;
            if (rc <= li && _comparer.Compare(_nodes[rc].Priority, _nodes[ci].Priority) < 0)
                ci = rc;
            if (_comparer.Compare(_nodes[pi].Priority, _nodes[ci].Priority) <= 0)
                break;
            var tmp = _nodes[pi];
            _nodes[pi] = _nodes[ci];
            _nodes[ci] = tmp;
            pi = ci;
        }
        return frontItem;
    }

    public bool TryDequeue(out TElement element, out TPriority priority)
    {
        if (_nodes.Count == 0)
        {
            element = default;
            priority = default;
            return false;
        }
        priority = _nodes[0].Priority;
        element = Dequeue();
        return true;
    }

    public void Clear() => _nodes.Clear();
}