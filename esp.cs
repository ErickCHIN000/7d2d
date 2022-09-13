using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace _7d2dCheat
{
    internal class esp : MonoBehaviour
    {
        public static Camera cam;
        private static Vector3 eb_head, eb_neck, eb_spine, eb_leftshoulder, eb_leftarm, eb_leftforearm, eb_lefthand, eb_rightshoulder, eb_rightarm, eb_rightforearm;
        private static Vector3 eb_righthand, eb_hips, eb_leftupleg, eb_leftleg, eb_leftfoot, eb_rightupleg, eb_rightleg, eb_rightfoot;

        private void OnGUI()
        {
            if (global.IsWorldPresent() && global.Entities != null)
            {
                foreach (Entity entity in global.Entities)
                {
                    if (entity.IsAlive())
                    {
                        if (entity is EntityAnimal && global.showAnimalEsp) esp_drawBox(entity, Color.green, Color.green, true);
                        if (entity is EntityEnemy && global.showZombieEsp) esp_drawBox(entity, Color.red, Color.red, true);
                    }
                }
            }
        }

        private void Update()
        {
            if (cam == null)
            {
                cam = Camera.main;
            }
        }

        public static void esp_drawBox(Entity entity, Color boxColor, Color skeletonColor, bool name)
        {
            Vector3 entity_head = entity.transform.position;
            Vector3 entity_feet = new Vector3(entity_head.x, entity_head.y + entity.height, entity_head.z);

            Vector3 w2s_head = cam.WorldToScreenPoint(entity_head);
            Vector3 w2s_feet = cam.WorldToScreenPoint(entity_feet);

            float Distance = Vector3.Distance(entity.transform.position, global.player.transform.position);
            Vector3 w2s_test = cam.WorldToScreenPoint(entity.emodel.GetHeadTransform().position);

            if (w2s_head.z > 0f && w2s_head.x > 0 && w2s_head.x < (float)Screen.width && w2s_head.y > 0 && Distance <= 100f)
            {
                if (global.espBox)
                {
                    if (name) DrawESPBox(w2s_feet, w2s_head, boxColor);
                    else DrawESPBox(w2s_feet, w2s_head, boxColor);
                    //DrawESPBox(w2s_test, new Vector3(w2s_test.x - 1f, w2s_test.y - 1f, w2s_test.z), boxColor, "");
                }

                if (global.espName)
                {
                    render.DrawString(new Vector2(w2s_feet.x /*- (width / 2)*/, (float)Screen.height - w2s_feet.y - (w2s_head.y - w2s_feet.y) - 10f), entity.transform.parent.name, Color.white, true);
                }

                if (global.espBones)
                {
                    Transform[] entityBones = entity.GetComponentInChildren<SkinnedMeshRenderer>().bones;
                    int canBone = 0;

                    for (int j = 0; j < entityBones.Length; j++)
                    {
                        if (entityBones[j].name == "Head") { eb_head = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Head
                        if (entityBones[j].name == "Neck") { eb_neck = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Neck
                        if (entityBones[j].name == "Spine") { eb_spine = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Spine
                        if (entityBones[j].name == "LeftShoulder") { eb_leftshoulder = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftShoulder
                        if (entityBones[j].name == "LeftArm") { eb_leftarm = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftArm
                        if (entityBones[j].name == "LeftForeArm") { eb_leftforearm = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftForeArm
                        if (entityBones[j].name == "LeftHand") { eb_lefthand = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftHand
                        if (entityBones[j].name == "RightShoulder") { eb_rightshoulder = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightShoulder
                        if (entityBones[j].name == "RightArm") { eb_rightarm = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightArm
                        if (entityBones[j].name == "RightForeArm") { eb_rightforearm = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightForeArm
                        if (entityBones[j].name == "RightHand") { eb_righthand = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightHand
                        if (entityBones[j].name == "Hips") { eb_hips = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //Hips
                        if (entityBones[j].name == "LeftUpLeg") { eb_leftupleg = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftUpLeg
                        if (entityBones[j].name == "LeftLeg") { eb_leftleg = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftLeg
                        if (entityBones[j].name == "LeftFoot") { eb_leftfoot = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //LeftFoot
                        if (entityBones[j].name == "RightUpLeg") { eb_rightupleg = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightUpLeg
                        if (entityBones[j].name == "RightLeg") { eb_rightleg = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightLeg
                        if (entityBones[j].name == "RightFoot") { eb_rightfoot = cam.WorldToScreenPoint(entityBones[j].transform.position); canBone++; } //RightFoot
                    }

                    if (canBone >= 18)
                    {
                        DrawESPLine(eb_head, eb_neck, skeletonColor);
                        DrawESPLine(eb_neck, eb_spine, skeletonColor);
                        DrawESPLine(eb_spine, eb_hips, skeletonColor);

                        DrawESPLine(eb_hips, eb_leftupleg, skeletonColor);
                        DrawESPLine(eb_leftupleg, eb_leftleg, skeletonColor);
                        DrawESPLine(eb_leftleg, eb_leftfoot, skeletonColor);
                        DrawESPLine(eb_hips, eb_rightupleg, skeletonColor);
                        DrawESPLine(eb_rightupleg, eb_rightleg, skeletonColor);
                        DrawESPLine(eb_rightleg, eb_rightfoot, skeletonColor);

                        DrawESPLine(eb_neck, eb_leftshoulder, skeletonColor);
                        DrawESPLine(eb_leftshoulder, eb_leftarm, skeletonColor);
                        DrawESPLine(eb_leftarm, eb_leftforearm, skeletonColor);
                        DrawESPLine(eb_leftforearm, eb_lefthand, skeletonColor);

                        DrawESPLine(eb_neck, eb_rightshoulder, skeletonColor);
                        DrawESPLine(eb_rightshoulder, eb_rightarm, skeletonColor);
                        DrawESPLine(eb_rightarm, eb_rightforearm, skeletonColor);
                        DrawESPLine(eb_rightforearm, eb_righthand, skeletonColor);
                    }
                }
            }
        }

        private static void DrawESPBox(Vector3 objfootPos, Vector3 objheadPos, Color objColor)
        {
            float height = objheadPos.y - objfootPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            render.DrawBox(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height, width, height, objColor, 2f);
        }

        private static void DrawESPLine(Vector3 pointA, Vector3 pointB, Color objColor)
        {
            render.DrawLine(new Vector2(pointA.x, (float)Screen.height - pointA.y), new Vector2(pointB.x, (float)Screen.height - pointB.y), objColor, 1f);
        }
    }
}