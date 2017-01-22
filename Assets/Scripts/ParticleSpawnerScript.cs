using UnityEngine;

public class ParticleSpawnerScript : MonoBehaviour
{
    public int segments;
    public float radius;
    public SegmentScript sample;
    public const float distance = 0.4f;

    private SegmentScript[] _particles;

    void Start()
    {
        _particles = new SegmentScript[segments];

        float angle = 20f;
        for (int i = 0; i < segments; i++)
        {
            var x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            var y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            _particles[i] = CreateParticle(x, y);
            _particles[i].name = i.ToString();

            if (i > 0)
                Connect(_particles[i], _particles[i - 1]);
            if (i == segments - 1)
                Connect(_particles[0], _particles[i]);

            angle += (360f / segments);
            _particles[i].GetComponent<SegmentScript>().SetDirection(x, y);
        }
    }

    void Update()
    {
        UpdateConnectingLines();
        if (transform.childCount <= 1)
        {
            Destroy(gameObject);
        }
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
        if (line == null)
            return;

        line.sortingOrder = 2;
        line.numPositions = 2;
        line.SetPosition(0, particle1.transform.position);
        line.SetPosition(1, particle2.transform.position);
    }

    void UpdateConnectingLines()
    {
        for (int i = 0; i < segments; i++)
        {
            if (i > 0)
            {
                Connect(_particles[i], _particles[i - 1]);
                if (_particles[i] != null 
                    && _particles[i - 1] != null 
                    && Vector3.Distance(_particles[i].transform.position, _particles[i - 1].transform.position) > distance)
                    DisableLineRenderer(_particles[i]);
            }
            if (i == segments - 1)
            {
                Connect(_particles[0], _particles[i]);
                if (_particles[0] != null 
                    && _particles[i] != null 
                    && Vector3.Distance(_particles[0].transform.position, _particles[i].transform.position) > distance)
                    DisableLineRenderer(_particles[0]);
            }
            if (_particles[i] != null) continue;
            if (i < segments - 1)
                DisableLineRenderer(_particles[i + 1]);
            if (i == segments - 1)
                DisableLineRenderer(_particles[0]);
        }
    }
    void DisableLineRenderer(SegmentScript particle)
    {
        if (particle == null)
            return;

        Destroy(particle.GetComponent<LineRenderer>());
    }
}