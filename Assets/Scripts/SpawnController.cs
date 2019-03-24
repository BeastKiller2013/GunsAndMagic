using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
	public List<Spawner> spawners;

	class SpawnSequence
	{
		public SpawnSequence(Spawner s, float d, int cg)
		{
			spawner = s;
			delay = d;
			countGoal = cg;
			count = 0;
			countdown = 0;
		}

		public void doTick(float dTime)
		{
			if (countdown <= 0 && count < countGoal)
			{
				spawner.doSpawn();
				this.countdown = delay;
				this.count++;
			}
			else
			{
				countdown -= dTime;
			}
		}

		Spawner spawner;

		float countdown;
		float delay;
		int countGoal;
		int count;
	}

	List<SpawnSequence> sequences;

    // Start is called before the first frame update
    void Start()
    {
		sequences = new List<SpawnSequence>();
		sequences.Add(new SpawnSequence(spawners[0], 2f, 5));
		sequences.Add(new SpawnSequence(spawners[1], 2f, 5));
		sequences.Add(new SpawnSequence(spawners[2], 2f, 5));
		sequences.Add(new SpawnSequence(spawners[3], 2f, 5));
		sequences.Add(new SpawnSequence(spawners[4], 2f, 5));
	}

    // Update is called once per frame
    void Update()
    {
        foreach(SpawnSequence seq in sequences)
		{
			seq.doTick(Time.deltaTime);
		}
    }
}