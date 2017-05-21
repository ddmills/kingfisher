using UnityEngine;
using System.Collections.Generic;

namespace King.Component {
  public class ResourceManifestation : MonoBehaviour {
    public Resource resource;
    public int quantity;
    [System.Serializable]
    public class Reservation {
      public Reservation(Object reservee, int quantity) {
        this.reservee = reservee;
        this.quantity = quantity;
      }

      public Object reservee;
      public int quantity;
    }
    public List<Reservation> reservations;

    public void PopulateByEntry(ResourceMap.ResourceEntry entry) {
      this.resource = entry.resource;
      this.quantity = entry.quantity;
    }

    public bool CanSplit(int quantity) {
      return quantity <= this.quantity;
    }

    public ResourceManifestation Split(int quantity) {
      if (quantity == this.quantity) {
        return this;
      }
      ResourceManifestation manifestation = resource.Manifest(transform.position, quantity);
      this.quantity -= quantity;
      return manifestation;
    }

    public Reservation GetReservation(Object candidate) {
      return reservations.Find(reservation => reservation.reservee.Equals(candidate));
    }

    public bool IsReservedBy(Object candidate) {
      return GetReservation(candidate) != null;
    }

    public int UnreservedQuantity() {
      int reserved = 0;

      reservations.ForEach(reservation => {
        reserved += reservation.quantity;
      });

      return quantity - reserved;
    }

    public void Reserve(Object reservee, int quantity) {
      Reservation reservation = GetReservation(reservee);
      if (reservation != null) {
        reservation.quantity += quantity;
      } else {
        reservations.Add(new Reservation(reservee, quantity));
      }
    }

    public void ReserveRemaining(Object reservee) {
      Reserve(reservee, UnreservedQuantity());
    }

    public Reservation Unreserve(Object reservee) {
      Reservation reservation = GetReservation(reservee);
      reservations.Remove(reservation);
      return reservation;
    }

    public Reservation Unreserve(Object reservee, int quantity) {
      Reservation reservation = GetReservation(reservee);
      if (reservation != null) {
        if (quantity >= reservation.quantity) {
          reservations.Remove(reservation);
          return reservation;
        }
        reservation.quantity -= quantity;
      }
      return reservation;
    }

    public ResourceManifestation Redeem(Object candidate) {
      Reservation reservation = Unreserve(candidate);
      if (reservation != null) {
        return Split(reservation.quantity);
      }
      return null;
    }

    public ResourceManifestation Redeem(Object candidate, int quantity) {
      Reservation reservation = Unreserve(candidate, quantity);
      if (reservation != null) {
        return Split(quantity);
      }
      return null;
    }
  }
}
