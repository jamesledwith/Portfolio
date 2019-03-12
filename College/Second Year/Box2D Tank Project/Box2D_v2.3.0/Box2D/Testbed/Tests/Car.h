/*
* Copyright (c) 2006-2011 Erin Catto http://www.box2d.org
*
* This software is provided 'as-is', without any express or implied
* warranty.  In no event will the authors be held liable for any damages
* arising from the use of this software.
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications, and to alter it and redistribute it
* freely, subject to the following restrictions:
* 1. The origin of this software must not be misrepresented; you must not
* claim that you wrote the original software. If you use this software
* in a product, an acknowledgment in the product documentation would be
* appreciated but is not required.
* 2. Altered source versions must be plainly marked as such, and must not be
* misrepresented as being the original software.
* 3. This notice may not be removed or altered from any source distribution.
*/

#ifndef CAR_H
#define CAR_H

// This is a fun demo that shows off the wheel joint
class Car : public Test
{
public:
	Car()
	{
		m_hz = 4.0f;
		m_zeta = 0.7f;
		m_speed = 25.0f;

		b2Body* ground = NULL;
		{
			b2BodyDef bd;
			ground = m_world->CreateBody(&bd);

			b2EdgeShape shape;

			b2FixtureDef fd;
			fd.shape = &shape;
			fd.density = 0.0f;
			fd.friction = 0.6f;

			shape.Set(b2Vec2(-20.0f, 0.0f), b2Vec2(20.0f, 0.0f));
			ground->CreateFixture(&fd);

			float32 hs[10] = { 0.25f, 1.0f, 4.0f, 0.0f, 0.0f, -1.0f, -2.0f, -2.0f, -1.25f, 0.0f };

			float32 x = 20.0f, y1 = 0.0f, dx = 5.0f;

			for (int32 i = 0; i < 10; ++i)
			{
				float32 y2 = hs[i];
				shape.Set(b2Vec2(x, y1), b2Vec2(x + dx, y2));
				ground->CreateFixture(&fd);
				y1 = y2;
				x += dx;
			}

			for (int32 i = 0; i < 10; ++i)
			{
				float32 y2 = hs[i];
				shape.Set(b2Vec2(x, y1), b2Vec2(x + dx, y2));
				ground->CreateFixture(&fd);
				y1 = y2;
				x += dx;
			}

			shape.Set(b2Vec2(x, 0.0f), b2Vec2(x + 40.0f, 0.0f));
			ground->CreateFixture(&fd);

			x += 80.0f;
			shape.Set(b2Vec2(x, 0.0f), b2Vec2(x + 40.0f, 0.0f));
			ground->CreateFixture(&fd);

			x += 40.0f;
			shape.Set(b2Vec2(x, 0.0f), b2Vec2(x + 10.0f, 5.0f));
			ground->CreateFixture(&fd);

			x += 20.0f;
			shape.Set(b2Vec2(x, 0.0f), b2Vec2(x + 40.0f, 0.0f));
			ground->CreateFixture(&fd);

			x += 40.0f;
			shape.Set(b2Vec2(x, 0.0f), b2Vec2(x, 20.0f));
			ground->CreateFixture(&fd);
		}

		// Teeter
		{
			b2BodyDef bd;
			bd.position.Set(140.0f, 1.0f);
			bd.type = b2_dynamicBody;
			b2Body* body = m_world->CreateBody(&bd);

			b2PolygonShape box;
			box.SetAsBox(10.0f, 0.25f);
			body->CreateFixture(&box, 1.0f);

			b2RevoluteJointDef jd;
			jd.Initialize(ground, body, body->GetPosition());
			jd.lowerAngle = -8.0f * b2_pi / 180.0f;
			jd.upperAngle = 8.0f * b2_pi / 180.0f;
			jd.enableLimit = true;
			m_world->CreateJoint(&jd);

			body->ApplyAngularImpulse(100.0f, true);
		}

		// Bridge
		{
			int32 N = 20;
			b2PolygonShape shape;
			shape.SetAsBox(1.0f, 0.125f);

			b2FixtureDef fd;
			fd.shape = &shape;
			fd.density = 1.0f;
			fd.friction = 0.6f;

			b2RevoluteJointDef jd;

			b2Body* prevBody = ground;
			for (int32 i = 0; i < N; ++i)
			{
				b2BodyDef bd;
				bd.type = b2_dynamicBody;
				bd.position.Set(161.0f + 2.0f * i, -0.125f);
				b2Body* body = m_world->CreateBody(&bd);
				body->CreateFixture(&fd);

				b2Vec2 anchor(160.0f + 2.0f * i, -0.125f);
				jd.Initialize(prevBody, body, anchor);
				m_world->CreateJoint(&jd);

				prevBody = body;
			}

			b2Vec2 anchor(160.0f + 2.0f * N, -0.125f);
			jd.Initialize(prevBody, ground, anchor);
			m_world->CreateJoint(&jd);
		}

		// Boxes
		{
			b2PolygonShape box;
			box.SetAsBox(0.5f, 0.5f);

			b2Body* body = NULL;
			b2BodyDef bd;
			bd.type = b2_dynamicBody;

			bd.position.Set(230.0f, 0.5f);
			body = m_world->CreateBody(&bd);
			body->CreateFixture(&box, 0.5f);

			bd.position.Set(230.0f, 1.5f);
			body = m_world->CreateBody(&bd);
			body->CreateFixture(&box, 0.5f);

			bd.position.Set(230.0f, 2.5f);
			body = m_world->CreateBody(&bd);
			body->CreateFixture(&box, 0.5f);

			bd.position.Set(230.0f, 3.5f);
			body = m_world->CreateBody(&bd);
			body->CreateFixture(&box, 0.5f);

			bd.position.Set(230.0f, 4.5f);
			body = m_world->CreateBody(&bd);
			body->CreateFixture(&box, 0.5f);
		}

		// Car
		{
			/*b2PolygonShape chassis;
			b2Vec2 vertices[10];
			vertices[0].Set(1.23f, 1.06f);
			vertices[1].Set(1.37f, 1.22f);
			vertices[2].Set(1.81f, 1.23f);
			vertices[3].Set(4.1f, 1.2f);
			vertices[4].Set(4.24f, 1.1f);
			vertices[5].Set(4.0f, 1.0f);
			vertices[6].Set(3.98f, 0.68f);
			vertices[7].Set(1.47f, 0.69f);
			vertices[8].Set(1.46f, 0.97f);
			vertices[9].Set(1.24f, 0.98f);
			chassis.Set(vertices, 10);
			*/
			b2PolygonShape chassis;
			b2Vec2 vertices[8];
			vertices[0].Set(-2.21f, -0.15f);
			vertices[1].Set(2.13f, -0.15f);
			vertices[2].Set(2.24f, 0.24f);
			vertices[3].Set(2.13f, 0.67f);
			vertices[4].Set(-2.08f, 0.67f);
			vertices[5].Set(-2.33f, 0.33f);
			chassis.Set(vertices, 6);

			b2PolygonShape chassisTurret;
			vertices[0].Set(-1.11f, 1.38f);
			vertices[1].Set(-1.12f, 0.67f);
			vertices[2].Set(0.97f, 0.67f);
			vertices[3].Set(0.95f, 1.4f);
			chassisTurret.Set(vertices, 4);

			/*b2PolygonShape barrel;
			b2Vec2 vertices[4];
			vertices[0].Set(2.07f, 1.58f);
			vertices[1].Set(2.07f, 1.49f);
			vertices[2].Set(1.6f, 1.5f);
			vertices[3].Set(1.6f, 1.5f);
			chassis.Set(vertices, 4);

			b2PolygonShape chassisHatch;
			vertices[0].Set(2.77f, 1.83f);
			vertices[1].Set(3.16f, 1.84f);
			vertices[2].Set(3.2f, 1.77f);
			vertices[3].Set(3.16f, 1.7f);
			vertices[4].Set(2.33f, 1.67f);
			chassisHatch.Set(vertices, 5);
			*/

			b2PolygonShape barrel;
			barrel.SetAsBox(1.0f, 0.08f, b2Vec2(1.75f, 1.05f), 0.0f);

			b2CircleShape circle;
			circle.m_radius = 0.3f;

			b2BodyDef bd;
			bd.type = b2_dynamicBody;
			bd.position.Set(0.0f, 1.0f);

			b2FixtureDef bfd;
			bfd.density = 1.0f;

			bfd.filter.categoryBits = 0x0006;
			bfd.filter.maskBits = 0xFFFF & ~0x0008;

			bfd.shape = &chassis;
			m_car = m_world->CreateBody(&bd);
			m_car->CreateFixture(&chassis, 1.0f);

			//m_chassisTop = m_world->CreateBody(&bd);
			//m_chassisTop->CreateFixture(&chassisTop, 1.0f);

			bfd.shape = &chassisTurret;
			m_chassisTurret = m_world->CreateBody(&bd);
			m_chassisTurret->CreateFixture(&chassisTurret, 1.0f);
			/*
			bfd.shape = &chassisHatch;
			m_chassisHatch = m_world->CreateBody(&bd);
			m_chassisHatch->CreateFixture(&chassisHatch, 1.0f);
			*/
			bfd.shape = &barrel;
			m_barrel = m_world->CreateBody(&bd);
			m_barrel->CreateFixture(&bfd);

			b2DistanceJointDef jtd;
			jtd.collideConnected = true;
			jtd.length = 0.2f;
			jtd.Initialize(m_car, m_chassisTurret, b2Vec2(-0.25f, 0.9f), b2Vec2(-0.25f, 1.1f));
			m_carturret = (b2DistanceJoint*)m_world->CreateJoint(&jtd);

			b2DistanceJoint*m_carturret;

			b2RevoluteJoint*m_turretbarrel;

			b2RevoluteJointDef jtbd;
			jtbd.lowerAngle = -0.1f*b2_pi;
			jtbd.upperAngle = 0.1f*b2_pi;
			jtbd.enableLimit = true;
			jtbd.motorSpeed = 0.0f;
			jtbd.maxMotorTorque = 100.0f;
			jtbd.enableMotor = true;
			jtbd.Initialize(m_chassisTurret, m_barrel, b2Vec2(0.9f, 1.475f));
			m_turretbarrel = (b2RevoluteJoint*)m_world->CreateJoint(&jtbd);

			b2FixtureDef fd;
			fd.shape = &circle;
			fd.density = 1.0f;
			fd.friction = 0.9f;

			fd.filter.categoryBits = 0x0002;
			fd.filter.maskBits = 0xFFFF;

			bd.position.Set(-1.2f, 0.4f);
			m_wheel1 = m_world->CreateBody(&bd);
			m_wheel1->CreateFixture(&fd);

			bd.position.Set(1.2f, 0.4f);
			m_wheel2 = m_world->CreateBody(&bd);
			m_wheel2->CreateFixture(&fd);

			bd.position.Set(-1.8f, 0.4f);
			m_wheel5 = m_world->CreateBody(&bd);
			m_wheel5->CreateFixture(&fd);

			bd.position.Set(1.8f, 0.4f);
			m_wheel4 = m_world->CreateBody(&bd);
			m_wheel4->CreateFixture(&fd);

			bd.position.Set(0.6f, 0.4f);
			m_wheel3 = m_world->CreateBody(&bd);
			m_wheel3->CreateFixture(&fd);

			bd.position.Set(-0.6f, 0.4f);
			m_wheel6 = m_world->CreateBody(&bd);
			m_wheel6->CreateFixture(&fd);

			bd.position.Set(0.0f, 0.4f);
			m_wheel7 = m_world->CreateBody(&bd);
			m_wheel7->CreateFixture(&fd);

			b2WheelJointDef jd;
			b2Vec2 axis(0.0f, 1.0f);

			jd.Initialize(m_car, m_wheel1, m_wheel1->GetPosition(), axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 20.0f;
			jd.enableMotor = true;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring1 = (b2WheelJoint*)m_world->CreateJoint(&jd);

			jd.Initialize(m_car, m_wheel2, m_wheel2->GetPosition(), axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 10.0f;
			jd.enableMotor = true;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring2 = (b2WheelJoint*)m_world->CreateJoint(&jd);

			jd.Initialize(m_car, m_wheel3, m_wheel3->GetPosition(), axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 20.0f;
			jd.enableMotor = true;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring3 = (b2WheelJoint*)m_world->CreateJoint(&jd);

			jd.Initialize(m_car, m_wheel4, m_wheel4->GetPosition(), axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 10.0f;
			jd.enableMotor = true;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring4 = (b2WheelJoint*)m_world->CreateJoint(&jd);

			jd.Initialize(m_car, m_wheel5, m_wheel5->GetPosition(), axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 10.0f;
			jd.enableMotor = true;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring5 = (b2WheelJoint*)m_world->CreateJoint(&jd);


			jd.Initialize(m_car, m_wheel6, m_wheel6->GetPosition(), axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 10.0f;
			jd.enableMotor = true;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring6 = (b2WheelJoint*)m_world->CreateJoint(&jd);


			jd.Initialize(m_car, m_wheel7, m_wheel7->GetPosition(), axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 10.0f;
			jd.enableMotor = false;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring7 = (b2WheelJoint*)m_world->CreateJoint(&jd);

			b2PolygonShape shape;

			//tracks

			b2RevoluteJointDef jtrd;

			jtrd.collideConnected = false;
			jtrd.localAnchorA.Set(0.1f, 0.0f);  // Joint is set to be at the end of each track section
			jtrd.localAnchorB.Set(-0.1f, 0.0f); // Joint is set to be at the end of each track section

			fd.filter.categoryBits = 0x0008;
			fd.filter.maskBits = 0xFFFF & ~0x0004;
			fd.density = 1.0f;
			//Track size 1
			shape.SetAsBox(0.1f, 0.04f);
			fd.shape = &shape;


			//Along the top from left to right of far left wheel
			// i< how many you want across the top
			for (int i = 0; i<13; i++)
			{
				if (!i) // if the counter i is at 0.
				{
					// set at x,y - x being middle of far left wheel and y being your wheel size above the y middle of the wheel
					bd.position.Set(-1.7f, 0.83f);
					m_prev_track = m_world->CreateBody(&bd);
					m_prev_track->CreateFixture(&fd);
					m_first_track = m_prev_track;	// Set the position of the first track so we can complete the circuit
				}
				else
				{
					// set x,y the same as above ^^ just leave the +i*0.2f
					bd.position.Set(-1.7f + i*0.2f, 0.83f);
					m_track = m_world->CreateBody(&bd);
					m_track->CreateFixture(&fd);
					jtrd.bodyA = m_prev_track;
					jtrd.bodyB = m_track;
					m_world->CreateJoint(&jtrd);
					m_prev_track = m_track;
				}
			}

			b2Vec2 a, p;	// Two vector: a for actual position of track, p for the centre of rotation (the wheel hub).
			a.x = 2.0f;		// x position at base of front wheel
			a.y = 0.8f;	// y position at base of front wheel
			p.x = 2.0f;		// x position at centre of front wheel
			p.y = 0.4f;	// y position at centre of front wheel

			float theta, theta_old;

			//Around front wheel at (1.0,0.4) of radius 0.4;(mine)
			// i< how many you want around front wheel
			for (int i = 0; i<9; i++)
			{
				theta = -i*b2_pi / 8.0f;
				theta_old = -(i - 1)*b2_pi / 8.0f;	// Keep track of previous theta so anchor A is set correctly.

				if (i>1) jtrd.localAnchorA.Set(0.1f*cos(theta_old), 0.1f*sin(theta_old));
				jtrd.localAnchorB.Set(-0.1f*cos(theta), -0.1f*sin(theta));

				//Track size 2, keep them consistent from above^^
				shape.SetAsBox(0.1f, 0.04f, b2Vec2(0.0f, 0.0f), theta); // box shape rotated through theta
				bd.position.Set(a.x*cos(theta) - a.y*sin(theta) + p.x*(1 - cos(theta)) + p.y*sin(theta),
					a.x*sin(theta) + a.y*cos(theta) + p.y*(1 - cos(theta)) - p.x*sin(theta) + 0.03f); // position box according to your notes

				m_track = m_world->CreateBody(&bd);
				m_track->CreateFixture(&fd);

				jtrd.bodyA = m_prev_track;
				jtrd.bodyB = m_track;

				m_world->CreateJoint(&jtrd);
				m_prev_track = m_track;
			}

			jtrd.localAnchorA.Set(0.1f*cos(theta), 0.1f*sin(theta)); //Reset anchors for tracks outside rotation
			jtrd.localAnchorB.Set(0.1f, 0.0f);

			//i< how many you want along the bottom
			for (int i = 0; i<13; i++)
			{
				jtrd.localAnchorA.Set(-0.1f, 0.0f); //Reset Anchor A.

				bd.position.Set(p.x - (i + 1)*0.2f, 0.025f);
				m_track = m_world->CreateBody(&bd);
				m_track->CreateFixture(&fd);
				jtrd.bodyA = m_prev_track;
				jtrd.bodyB = m_track;
				m_world->CreateJoint(&jtrd);
				m_prev_track = m_track;
			}

			a.x = -2.0f; // x position at base of rear wheel
			a.y = 0.001f; // y position at base of rear wheel
			p.x = -2.0f;	// x position of the rear wheel hub.
			p.y = 0.35f;		// y position of the rear wheel hub.

			//Around back wheel at (-1.0,0.4) of radius 0.4;
			for (int i = 0; i<9; i++)
			{
				theta = -i*b2_pi / 8.0f;
				if (i>1)theta_old = -(i - 1)*b2_pi / 8.0f; // Keep track of previous theta so anchor A is set correctly.

				if (i>1) jtrd.localAnchorA.Set(-0.1f*cos(theta_old), -0.1f*sin(theta_old));
				jtrd.localAnchorB.Set(0.1f*cos(theta), 0.1f*sin(theta));

				//Track size 3 same as above^^
				shape.SetAsBox(0.1f, 0.04f, b2Vec2(0.0f, 0.0f), theta);
				bd.position.Set(a.x*cos(theta) - a.y*sin(theta) + p.x*(1 - cos(theta)) + p.y*sin(theta),
					a.x*sin(theta) + a.y*cos(theta) + p.y*(1 - cos(theta)) - p.x*sin(theta) + 0.03f);

				m_track = m_world->CreateBody(&bd);
				m_track->CreateFixture(&fd);

				jtrd.bodyA = m_prev_track;
				jtrd.bodyB = m_track;

				m_world->CreateJoint(&jtrd);
				m_prev_track = m_track;
			}

			//Connect last link to first link
			jtrd.localAnchorA.Set(-0.1f*cos(theta), -0.1f*sin(theta));
			jtrd.localAnchorB.Set(-0.1f, 0.0);
			jtrd.bodyB = m_first_track;
			jtrd.bodyA = m_prev_track;
			m_world->CreateJoint(&jtrd);

		}
	}

	void Keyboard(unsigned char key)
	{
		switch (key)
		{
		case 'a':
			m_spring1->SetMotorSpeed(m_speed);
			m_spring2->SetMotorSpeed(m_speed);
			m_spring3->SetMotorSpeed(m_speed);
			m_spring4->SetMotorSpeed(m_speed);
			m_spring6->SetMotorSpeed(m_speed);
			m_spring7->SetMotorSpeed(m_speed);
			break;

		case 's':
			m_spring1->SetMotorSpeed(0.0f);
			m_spring2->SetMotorSpeed(0.0f);
			m_spring3->SetMotorSpeed(0.0f);
			m_spring4->SetMotorSpeed(0.0f);
			m_spring6->SetMotorSpeed(0.0f);
			m_spring7->SetMotorSpeed(0.0f);
			break;

		case 'd':
			m_spring1->SetMotorSpeed(-m_speed);
			m_spring2->SetMotorSpeed(-m_speed);
			m_spring3->SetMotorSpeed(-m_speed);
			m_spring4->SetMotorSpeed(-m_speed);
			m_spring6->SetMotorSpeed(-m_speed);
			m_spring7->SetMotorSpeed(-m_speed);
			break;

		case 'q':
			m_hz = b2Max(0.0f, m_hz - 1.0f);
			m_spring1->SetSpringFrequencyHz(m_hz);
			m_spring2->SetSpringFrequencyHz(m_hz);
			break;

		case 'e':
			m_hz += 1.0f;
			m_spring1->SetSpringFrequencyHz(m_hz);
			m_spring2->SetSpringFrequencyHz(m_hz);
			break;
		}
	}

	void Step(Settings* settings)
	{
		m_debugDraw.DrawString(5, m_textLine, "Keys: left = a, brake = s, right = d, hz down = q, hz up = e");
		m_textLine += DRAW_STRING_NEW_LINE;
		m_debugDraw.DrawString(5, m_textLine, "frequency = %g hz, damping ratio = %g", m_hz, m_zeta);
		m_textLine += DRAW_STRING_NEW_LINE;

		settings->viewCenter.x = m_car->GetPosition().x;
		Test::Step(settings);
	}

	static Test* Create()
	{
		return new Car;
	}

	b2Body* m_car;
	//b2Body* m_chassisTop;
	b2Body* m_chassisTurret;
	b2Body* m_chassisHatch;
	b2Body* m_wheel1;
	b2Body* m_wheel2;
	b2Body* m_wheel3;
	b2Body* m_wheel4;
	b2Body* m_wheel5;
	b2Body* m_wheel6;
	b2Body* m_wheel7;
	b2Body* m_track;
	b2Body* m_first_track;
	b2Body* m_prev_track;
	b2Body* m_barrel;

	float32 m_hz;
	float32 m_zeta;
	float32 m_speed;
	b2WheelJoint* m_spring1;
	b2WheelJoint* m_spring2;
	b2WheelJoint* m_spring3;
	b2WheelJoint* m_spring4;
	b2WheelJoint* m_spring5;
	b2WheelJoint* m_spring6;
	b2WheelJoint* m_spring7;

	b2DistanceJoint* m_carturret;
};

#endif
