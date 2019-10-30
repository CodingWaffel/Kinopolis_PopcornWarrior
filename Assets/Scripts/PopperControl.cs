using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


using Evertraxx;
/*
Takes the point of motion from Evertraxx class and if theres a collider near, it helps the user.
 */
public class PopperControl : CaptureControl {

	public float helperSpeed;
	public bool enableHelper;
	public float helperDistance;
	[Range(0.1f, 10)]
	public float helper;

	//Variables for triangular math stuff
	Collider2D[] colls;
	Vector2 orthogonale;
	Vector2 triangleA;
	Vector2 triangleB;
	Vector2 triangleC;
	float abDist;
	float acDist;

	protected override void Move(){
		CapturePosition tmp = CamCommunicator.CalcMovementPosition(Cam);
		if (!tmp.valid)
            {
                return;
            }
		Vector3 originalPosition = Cam.ScreenToWorldPoint(tmp.position);

		if(enableHelper){           

				//get distance to point to move
				Vector2 tmp2D = new Vector2(originalPosition.x, originalPosition.y);
				RaycastHit2D ray = Physics2D.Raycast(transform.position, originalPosition - transform.position, helperDistance);
				if(!ray){ 
				//get all colliders in range
					colls = Physics2D.OverlapCircleAll(transform.position, helperDistance);
					

					//Build "view-Frustum" in direction of point to move
					orthogonale = new Vector2((originalPosition - transform.position).y, - (originalPosition - transform.position).x);
					triangleA = transform.position;
					triangleB = tmp2D + orthogonale.normalized*helper;
					triangleC = tmp2D - orthogonale.normalized*helper;
                
					abDist = Vector2.Distance(triangleA, triangleB);
					acDist = Vector2.Distance(triangleA, triangleC);

					foreach (Collider2D col in colls)
					{
						if(!col.gameObject == gameObject && col.GetComponent<CircleCollider2D>()){

							//check if collider is in View-Frustum, move through collider if yes
							float xValue = orthogonale.normalized.x;
							float yValue = orthogonale.normalized.y;
							if(col.transform.position.x < orthogonale.x) xValue = -xValue;
							if(col.transform.position.y < orthogonale.y) yValue = -yValue;
							Vector2 movePointToMovement = new Vector2(xValue, yValue);
							Vector2 potentialPoint = new Vector2(col.transform.position.x, col.transform.position.y) + movePointToMovement;//* (col.GetComponent<CircleCollider2D>().radius -5);

							float distance = Vector2.Distance(potentialPoint, transform.position);
							
							
							if(distance <= abDist && distance <= acDist && distance >= 0){
								Vector2 dir = (potentialPoint - new Vector2(transform.position.x, transform.position.y)).normalized * (originalPosition - transform.position);//.normalized * helperDistance;
								transform.position = Vector3.MoveTowards(transform.position, dir, helperSpeed * Time.deltaTime);
								return;
							}
						}
					}
				}
				//No collider? move normally like motion tells
				transform.position =  originalPosition;
		}else{
            transform.position = originalPosition;
		}
	}
}
