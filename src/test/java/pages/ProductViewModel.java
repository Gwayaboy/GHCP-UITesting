package pages;

public class ProductViewModel {
    private int id;
    private String name;

    public ProductViewModel(int id, String name) {
        this.id = id;
        this.name = name;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }
}