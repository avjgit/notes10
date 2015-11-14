class Board
    attr_accessor :lines

    def to_s
        @lines.map do |l|
            l.map(&:to_s).join
        end.join("\n")
    end

    def initialize
        @lines = []
    end

    def open!
        @lines.each_with_index do |line, row|
            line.each_with_index do |cell, col|
                if cell.is_a?(Mine)
                    update_neighbors(row, col)
                end   
            end
        end
    end

    private 
    def update_neighbors (row, col)

        (row-1..row+1).each do |r|
            (col-1..col+1).each do |c|
                if 
            end
        end

        //update all neighbors
        // if neighbor is SafeCell
            // safecell.mines++

    end
end

class Mine
    def to_s
        '*'
    end
end

class SafeCell
    attr_accessor :mines

    def initialize
        @mines = 0
    end

    def to_s
        @mines
    end
end

class CellFactory
    def self.build(char)
        if char == '*'
            Mine.new
        else
            SafeCell.new
        end
    end
end

class BoardFactory

    def self.build(filename)
        board = Board.new

        File.open(filename) do | f |
            f.each_line.each do |line|
                
                cellsRow = []
                line.chars do |char|
                    cellsRow << CellFactory.build(char)
                end

                board.lines << cellsRow
            end
        end
        board
    end
end

board = BoardFactory.build('minesweeper_input.txt')
puts board
File.open('minesweeper_output.txt', 'w+') { |file| file << board }
