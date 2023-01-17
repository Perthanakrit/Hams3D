using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Test_Par_Enter : MonoBehaviour
{
    private ParticleSystem ps;
    public bool enter;
    public bool exit;
    public bool inside;
    public bool outside;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.parent = ps.transform;
        sphere.transform.localPosition = new Vector3(0.0f, 0.0f, 3.0f);
        sphere.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        //sphere.GetComponent<MeshRenderer>().material = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Particle.mat");

        var shape = ps.shape;
        shape.enabled = false;

        var trigger = ps.trigger;
        trigger.enabled = true;
        trigger.SetCollider(0, sphere.GetComponent<Collider>());
    }

    void Update()
    {
        var trigger = ps.trigger;
        trigger.enter = enter ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
        trigger.exit = exit ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
        trigger.inside = inside ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
        trigger.outside = outside ? ParticleSystemOverlapAction.Callback : ParticleSystemOverlapAction.Ignore;
    }

    void OnGUI()
    {
        enter = GUI.Toggle(new Rect(25, 40, 200, 30), enter, "Enter Callback");
        exit = GUI.Toggle(new Rect(25, 80, 200, 30), exit, "Exit Callback");
        inside = GUI.Toggle(new Rect(25, 120, 200, 30), inside, "Inside Callback");
        outside = GUI.Toggle(new Rect(25, 160, 200, 30), outside, "Outside Callback");
    }

    void OnParticleTrigger()
    {
        if (enter)
        {
            List<ParticleSystem.Particle> enterList = new List<ParticleSystem.Particle>();
            int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);

            for (int i = 0; i < numEnter; i++)
            {
                ParticleSystem.Particle p = enterList[i];
                p.startColor = new Color32(255, 0, 0, 255);
                enterList[i] = p;
            }

            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enterList);
        }

        if (exit)
        {
            List<ParticleSystem.Particle> exitList = new List<ParticleSystem.Particle>();
            int numExit = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exitList);

            for (int i = 0; i < numExit; i++)
            {
                ParticleSystem.Particle p = exitList[i];
                p.startColor = new Color32(0, 255, 0, 255);
                exitList[i] = p;
            }

            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Exit, exitList);
        }

        if (inside)
        {
            List<ParticleSystem.Particle> insideList = new List<ParticleSystem.Particle>();
            int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, insideList);

            for (int i = 0; i < numInside; i++)
            {
                ParticleSystem.Particle p = insideList[i];
                p.startColor = new Color32(0, 0, 255, 255);
                insideList[i] = p;
            }

            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, insideList);
        }

        if (outside)
        {
            List<ParticleSystem.Particle> outsideList = new List<ParticleSystem.Particle>();
            int numOutside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Outside, outsideList);

            for (int i = 0; i < numOutside; i++)
            {
                ParticleSystem.Particle p = outsideList[i];
                p.startColor = new Color32(0, 255, 255, 255);
                outsideList[i] = p;
            }

            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Outside, outsideList);
        }
    }
}
