﻿using System;
using System.Collections.Generic;
using System.Text;

using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged onDoorChanged;
        public DoorController(OnDoorChanged onDoorChanged)
        {
            this.door = new Door();
            this.onDoorChanged = onDoorChanged;
        }
        public void close()
        {
            this.door.close();
            this.onDoorChanged.doorStatusChanged("CLOSED", "dor is closed");
        }
        public void open()
        {
            this.door.open();
            this.onDoorChanged.doorStatusChanged("OPENED", "dor is opened");
        }
        public void activateLock()
        {
            if (this.door.isClosed())
            {
                this.door.activateLock();
                onDoorChanged.doorSecurityChanged("LOCKED", "door is locked");
            }
            else
            {
                unlock();
            }
        }
        public void unlock()
        {
            this.door.unlock();
            onDoorChanged.doorSecurityChanged("UNLOCKED", "door is unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void doorSecurityChanged(string vale, string message);
        void doorStatusChanged(string vale, string message);
    }

}
