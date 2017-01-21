using UnityEngine;

public class ParticleSpawnerScript : MonoBehaviour
{
    public int segments;
    public float radius;

    


    public SegmentScript sample;

    private SegmentScript[] particles;
    void Start()
    {
        particles = new SegmentScript[segments];

        float angle = 20f;
        for (int i = 0; i < segments; i++)
        {
            var x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            var y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            particles[i] = CreateParticle(x, y);

            if (i > 0 && i < segments)
                Connect(particles[i], particles[i - 1]);
            if (i == segments - 1)
                Connect(particles[0], particles[i]);

            angle += (360f / segments);
            particles[i].GetComponent<SegmentScript>().SetDirection(x, y);
        }
    }

    void Update()
    {
        UpdateConnectingLines();
    }

    private SegmentScript CreateParticle(float x, float y)
    {
        SegmentScript particle = Instantiate(sample, gameObject.transform) as SegmentScript;
        particle.transform.position = new Vector2(x + transform.position.x, y + transform.position.y);
        return particle;
    }

    void Connect(SegmentScript particle1, SegmentScript particle2)
    {
        if (particle1 == null || particle2 == null)
            return;

        LineRenderer line = particle1.GetComponent<LineRenderer>();
        line.sortingOrder = 2;
        line.numPositions = 2;
        line.SetPosition(0, particle1.transform.position);
        line.SetPosition(1, particle2.transform.position);
    }

    void UpdateConnectingLines()
    {
        for (int i = 0; i < segments; i++)
        {
            if (i > 0 && i < segments)
            {
                Connect(particles[i], particles[i - 1]);

                if (particles[i] == null
                    && i < segments - 1)
                    DisableLineRenderer(particles[i + 1]);
            }
            if (i == segments - 1)
            {
                Connect(particles[0], particles[i]);

                if (particles[i] == null)
                    DisableLineRenderer(particles[0]);
            }
        }
    }
    void DisableLineRenderer(SegmentScript particle)
    {
        if (particle == null)
            return;

        particle.GetComponent<LineRenderer>().enabled = false;
    }
}