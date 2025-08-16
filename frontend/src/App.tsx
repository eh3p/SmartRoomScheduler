import React, { useEffect, useState } from 'react'
import axios from 'axios'
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import timeGridPlugin from '@fullcalendar/timegrid'

const API_BASE = import.meta.env.VITE_API_BASE ?? 'http://localhost:5212'

type Room = { id:number; name:string; capacity:number; equipment:string; isActive:boolean }

export default function App() {
  const [rooms, setRooms] = useState<Room[]>([])

  useEffect(() => {
    axios.get(`${API_BASE}/api/rooms`).then(r => setRooms(r.data)).catch(console.error)
  }, [])

  return (
    <div style={{ padding: 16, fontFamily: 'system-ui' }}>
      <h1>Smart Room Scheduler</h1>
      <p>Backend: <code>{API_BASE}</code></p>

      <h2>Rooms</h2>
      <ul>
        {rooms.map(r => (
          <li key={r.id}>
            <strong>{r.name}</strong> — cap {r.capacity} — {r.equipment}
          </li>
        ))}
      </ul>

      <h2>Calendar</h2>
      <div style={{ background: '#fff' }}>
        <FullCalendar
          plugins={[dayGridPlugin, timeGridPlugin]}
          initialView="dayGridMonth"
          height={600}
          events={[
            { title: 'Sample Event', start: new Date().toISOString().slice(0,10) }
          ]}
        />
      </div>
    </div>
  )
}
